using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;




using Image = SixLabors.ImageSharp.Image;

namespace GlisseTonPiedBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("giroud")]
        public async Task PingAsync()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/732571903729860695/829710528498761758/isgiroud.mp4");
        }

        [Command("fouine")]
        public async Task AvatarAsync(SocketUser user = null, ushort size = 512)
        {
            if (user == null)
            {
                await ReplyAsync(CDN.GetUserAvatarUrl(Context.User.Id, Context.User.AvatarId, size, ImageFormat.Auto));
            }
            else
            {
                await ReplyAsync(CDN.GetUserAvatarUrl(user.Id, user.AvatarId, size, ImageFormat.Auto));
               // await ReplyAsync(user.GetAvatarUrl());
            }
        }

        [Command("brignness")]
        public async Task DistortionAvatar(SocketUser user = null, ushort size = 512)
        {
            EditImage editImage = new EditImage(CDN.GetUserAvatarUrl(user.Id, user.AvatarId, size, ImageFormat.Auto));
            Console.WriteLine(user.GetAvatarUrl());
            editImage.Brightness();
            

            await Context.Channel.SendFileAsync("image\\update.png", "Caption goes here");

        }

        [Command("text")]
        public async Task TextAvatar(SocketUser user = null,String text = "TEXT")
        {
            EditImage editImage = new EditImage(CDN.GetUserAvatarUrl(user.Id, user.AvatarId, 512, ImageFormat.Auto));
            Console.WriteLine(user.GetAvatarUrl());
            editImage.writeMessageOnImage(text);


            await Context.Channel.SendFileAsync("image\\update.png", "Caption goes here");

        }


    }
}
