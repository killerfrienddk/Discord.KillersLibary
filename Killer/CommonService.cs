﻿using System.Threading.Tasks;
using System.IO;
using Discord.WebSocket;
using Discord.Commands;
using Discord;
using Discord.Rest;

namespace KillersLibrary {
    public class CommonService {
        internal CommonService() { }
        static CommonService() { }

        private static readonly CommonService _instance = new();

        public static CommonService Instance {
            get { return _instance; }
        }

        #region Other
        /// <summary>
        ///     Gets the UserID depending on which of the two inputs are null.
        /// </summary>
        /// <param name="context">The <see cref="SocketCommandContext"/> is used to send normal commands.</param>
        /// <param name="command">The <see cref="SocketSlashCommand"/> is used to send slash commands.</param>
        /// <returns>A UserID from either <see cref="SocketCommandContext"/> or <see cref="SocketSlashCommand"/> depending on which is null.</returns>
        public ulong GetUserID(SocketCommandContext context = null, SocketSlashCommand command = null) {
            if (context == null) return command.User.Id;
            else return context.User.Id;
        }

        /// <summary>
        ///     Gets the GuildID depending on which of the two inputs are null.
        /// </summary>
        /// <param name="context">The <see cref="SocketCommandContext"/> is used to send normal commands.</param>
        /// <param name="command">The <see cref="SocketSlashCommand"/> is used to send slash commands.</param>
        /// <returns>A GuildID from either <see cref="SocketCommandContext"/> or <see cref="SocketSlashCommand"/> depending on which is null.</returns>
        public ulong GetGuildID(SocketCommandContext context = null, SocketSlashCommand command = null) {
            if (context == null) return ((SocketGuildUser)command.User).Guild.Id;
            else return context.Guild.Id;
        }

        /// <summary>
        ///     Gets the AuthorID depending on which of the two inputs are null.
        /// </summary>
        /// <param name="context">The <see cref="SocketCommandContext"/> is used to send normal commands.</param>
        /// <param name="command">The <see cref="SocketSlashCommand"/> is used to send slash commands.</param>
        /// <returns>A AuthorID from either <see cref="SocketCommandContext"/> or <see cref="SocketSlashCommand"/> depending on which is null.</returns>
        public ulong GetAuthorID(SocketCommandContext context = null, SocketSlashCommand command = null) {
            if (context == null) return command.User.Id;
            else return context.Message.Author.Id;
        }

        #region Responses
        /// <summary>
        ///     Sends a file using <see cref="ISocketMessageChannel"/> depending on which of the two inputs are null.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> is the image data you want to send.</param>
        /// <param name="filename">The filename of the attachment.</param>
        /// <param name="context">The <see cref="SocketCommandContext"/> is used to send normal commands.</param>
        /// <param name="command">The <see cref="SocketSlashCommand"/> is used to send slash commands.</param>
        public async Task MakeFileResponse(Stream stream, string filename, SocketCommandContext context = null, SocketSlashCommand command = null) {
            if (context == null) await command.Channel.SendFileAsync(stream, filename);
            else await context.Channel.SendFileAsync(stream, filename);
        }

        /// <summary>
        ///     Sends a file using <see cref="ISocketMessageChannel"/> depending on which of the two inputs are null.
        /// </summary>
        /// <param name="text">The text of the message to be sent.</param>
        /// <param name="embed">A single embed to send with this response. If this is passed alongside an array of embeds, the single embed will be ignored.</param>
        /// <param name="component">A <see cref="MessageComponent"/> to be sent with this response</param>
        /// <param name="context">The <see cref="SocketCommandContext"/> is used to send normal commands.</param>
        /// <param name="command">The <see cref="SocketSlashCommand"/> is used to send slash commands.</param>
        public async Task<RestUserMessage> MakeResponse(string text = null, Embed embed = null, MessageComponent component = null, SocketCommandContext context = null, SocketSlashCommand command = null) {
            if (context == null) return await command.FollowupAsync(text, embed: embed, component: component);
            else return await context.Channel.SendMessageAsync(text, embed: embed, component: component);
        }
        #endregion
        #endregion
    }
}