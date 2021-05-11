namespace CryoFall.AutoMessages
{
    using AtomicTorch.CBND.CoreMod.Bootstrappers;
    using AtomicTorch.CBND.CoreMod.Systems.Chat;
    using AtomicTorch.CBND.CoreMod.Systems.EmojiSystem;
    using AtomicTorch.CBND.CoreMod.Systems.ServerTimers;
    using AtomicTorch.CBND.GameApi.Data;
    using AtomicTorch.CBND.GameApi.Scripting;
    using AtomicTorch.GameEngine.Common.Helpers;
    using System;

    [PrepareOrder(afterType: typeof(BootstrapperServerCore))]
    public class BootstrapperAutoMessages : BaseBootstrapper
    {
        public static string SettingsFileName = "Data/Mods/AutoMessages.json";

        public AutoMessagesSettings Settings;

        private int currentOrder;

        public override void ServerInitialize(IServerConfiguration serverConfiguration)
        {
            LoadSettings(SettingsFileName);
            if (Settings.InSequentialOrder)
            {
                currentOrder = -1;
            }

            SendAutomatedMessage();
        }

        private void LoadSettings(string fileName)
        {
            // Check if settings file exists.
            // If it does, load it. Other wise create new settings and save it.

            Settings = new AutoMessagesSettings();
        }

        /// <summary>
        /// Just a stub for when I find methods to save/load data.
        /// </summary>
        /// <param name="fileName"></param>
        private void SaveSettings(string fileName)
        {
        }

        private string NextMessage()
        {
            if (Settings.InSequentialOrder)
            {
                currentOrder++;
                if (currentOrder >= Settings.Messages.Length)
                {
                    currentOrder = 0;
                }

                return Settings.Messages[currentOrder];
            }
            else
            {
                return Settings.Messages[RandomHelper.Next(0, Settings.Messages.Length)];
            }
        }

        private void SendAutomatedMessage()
        {
            try
            {
                string message = Settings.IncludePrefix ? $"{Settings.Prefix} " : "";
                message += NextMessage();
                if (Settings.ParseEmojis)
                {
                    message = EmojiHelper.ReplaceAsciiToUnicodeEmoji(message);
                }

                ChatSystem.ServerSendGlobalServiceMessage(message);
            }
            catch (NullReferenceException)
            {
                // Chat system isn't ready yet, try again next server frame.
                ServerTimersSystem.AddAction(0, SendAutomatedMessage);
                return;
            }

            ServerTimersSystem.AddAction(Settings.DelayBetweenMessages, SendAutomatedMessage);
        }
    }
}
