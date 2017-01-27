using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ungyrbot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] ungyrfile;

        string[] randomText;

        public MyBot()
        {
            rand = new Random();

            ungyrfile = new string[]
            {
"images/0B8fxfOg.jpg",
"images/13768286_1260842310615041_296960853_n.jpg",
"images/1pdyjbC.jpg",
"images/2mmjA4m.jpg",
"images/2SxNpGq.jpg",
"images/4hdDIFq.jpg",
"images/4PgbiEv.jpg",
"images/4vpOut1g.jpg",
"images/64BoRvP.jpg",
"images/6A9SWU3g.jpg",
"images/7dkTEbP.jpg",
"images/7Dl1lG4.jpg",
"images/8bH36Vx.jpg",
"images/9baejcz.jpg",
"images/b24bgO9.jpg",
"images/BM2Xby4g.jpg",
"images/bqHvIxN.jpg",
"images/bwhFTbZ.jpg",
"images/BXTNzpB.jpg",
"images/c2M08jW.jpg",
"images/CGJ1M10g.jpg",
"images/cjavF66g.jpg",
"images/Cv0BHysUkAAumTI.jpg",
"images/CvMZ1T8UkAAuozp.jpg",
"images/D85U8Pq.jpg",
"images/dAj7Wyb.jpg",
"images/e6WqZNI.jpg",
"images/EbeKtnug.jpg",
"images/EBGQxnn.jpg",
"images/ethhlle.jpg",
"images/Ew9AVcm.jpg",
"images/EyQMkAI.jpg",
"images/FTqZDbJ.jpg",
"images/fVcIC5S.jpg",
"images/fvYT5Nv.jpg",
"images/G2J0NdR.jpg",
"images/ggyVzpW.jpg",
"images/gnU9Pyo.jpg",
"images/GoOdrbk.jpg",
"images/HEuPmIY.jpg",
"images/htyucw7.jpg",
"images/hwL634c.jpg",
"images/JkaUb8a.jpg",
"images/Jq0IQjag.jpg",
"images/juJXFH2g.jpg",
"images/KBtI8hL.jpg",
"images/kGeGqqig.jpg",
"images/knbCSqM.jpg",
"images/ky6CDd8g.jpg",
"images/LjVk5GN.jpg",
"images/LUes4Xq.jpg",
"images/MGAzl3B.jpg",
"images/MlbDtyf.jpg",
"images/mZ8Bibg.jpg",
"images/Ney8Bp8g.jpg",
"images/ocwh16BEoD1ukp9i1o1.jpg",
"images/OcwJuN0.jpg",
"images/ojuhvksB2u1u5vllxo1.jpg",
"images/oMj09Edg.jpg",
"images/oQi4m5h.jpg",
"images/ppfm6OV.jpg",
"images/qFsVndR.jpg",
"images/qRnn9Nrg.jpg",
"images/RFWMSfog.jpg",
"images/Rkxr8Zi.jpg",
"images/rrORGuU.jpg",
"images/sEzLohO.jpg",
"images/sPO62yG.jpg",
"images/T8PX3FS.jpg",
"images/Tee0MbG.jpg",
"images/tFKPA7j.jpg",
"images/tGkMLIV.jpg",
"images/tgZimBr.jpg",
"images/uxibNAp.jpg",
"images/V92OLz1.jpg",
"images/W6HZUic.jpg",
"images/wHxVtVr.jpg",
"images/wI2n14x.jpg",
"images/WIy4pEtg.jpg",
"images/XkUsR3S.jpg",
"images/y5ZJZW1.jpg",
"images/zFzb3dmg.jpg"

            };

            randomText = new string[]
            {
                "Oh no...",
                "This can't be right.",
                "I hope this is what you wanted.",
                "I always find something... anything...",
                "Why did you want me to look this up?",
                "I'm sorry...",
                "Is this one okay?",
                "I'm lost for words on this one.",
                "Does this make us friends?",
                "Please let this work...",
                "Um...",
                "Eh...",
                "I didn't ask to be made.",
                "I can't do anything right...",
                ":frowning:"
            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            
            commands = discord.GetService<CommandService>();

            RegisterImageCommand();

            commands.CreateCommand("Hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("It's me. Ungyrbot...");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("Mjc0Mzk2MjAzNzAwMTkxMjMz.C2xgAw.VxVNDHetg2knOPp3yKMc1b3Pr6A", TokenType.Bot);
            });
        }

        private void RegisterImageCommand()
        {
            commands.CreateCommand("ungyr")
                .Parameter("a", ParameterType.Unparsed)
                .Do(async (e) =>
                {
                    int randomindex1 = rand.Next(randomText.Length);
                    string textToPost = randomText[randomindex1];
                    await e.Channel.SendMessage(textToPost);
                    int randomindex2 = rand.Next(ungyrfile.Length);
                    string imageToPost = ungyrfile[randomindex2];
                    await e.Channel.SendFile(imageToPost);
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}


