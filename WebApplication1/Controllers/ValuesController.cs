using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{

    public class incomingSlack
    {
        public string token { get; set; }
        public string team_id { get; set; }
        public string channel_id { get; set; }
        public string channel_name { get; set; }
        public string timestamp { get; set; }
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string text { get; set; }
        public string trigger_word { get; set; }
    }

    public class outgoingSlack
    {
        public string text { get; set; }
    }

    public class payload
    {
        public string imageURL { get; set; }
        public string text { get; set; }
    }

    public class SlackController : ApiController
    {
        payload[] paydirt = new payload[]
        {
            new payload { imageURL = "http://i.imgur.com/eUzat5J.jpg", text = "From above"},
            new payload { imageURL = "http://i.imgur.com/XCW3O.jpg", text = "Candy apple"},
            new payload { imageURL = "http://imgur.com/IBwJhFS", text = "Emily Sears"},
            new payload { imageURL = "http://i.imgur.com/KcOCD.jpg", text = "Pretty cute"},
            new payload { imageURL = "http://i.imgur.com/GN2SyKA.jpg", text = "In the pool"},
            new payload { imageURL = "http://i.imgur.com/J5JV494.jpg", text = "Hey boy .. you like what you see?"},
            new payload { imageURL = "http://i.imgur.com/gzW2QI3.jpg", text = "Love the cleavage"},
            new payload { imageURL = "http://i.imgur.com/5glAESE.jpg", text = "Jessica Biel"},
            new payload { imageURL = "http://i.slutzx.com/upload/2014/07/27/20140727015041-d38cdad3.gif", text = "Great dance [GIF]"},
            new payload { imageURL = "http://i.imgur.com/3cEDKUl.jpg", text = "Double O seven"},
            new payload { imageURL = "http://i.imgur.com/06GMokB.jpg", text = "Cleavage"},
            new payload { imageURL = "http://i.imgur.com/CCk6fXo.jpg", text = "From behind"},
            new payload { imageURL = "http://i.imgur.com/0IX0cYu.jpg", text = "Megan Fox"},
            new payload { imageURL = "http://i.imgur.com/1d0QKeb.jpg", text = "Rachel Hilbert"},
            new payload { imageURL = "http://i.slutzx.com/upload/2014/07/27/20140727015102-8ef69753.gif", text = "She can move it"},
            new payload { imageURL = "http://i.imgur.com/Cm8Ylif.jpg", text = "Nipples"},
            new payload { imageURL = "http://i.imgur.com/fqp0O3Z.jpg", text = "Tight dress, hot body"},
            new payload { imageURL = "http://i.imgur.com/UG3ZC1M.jpg", text = "Constance Jablonski"},
            new payload { imageURL = "http://i.imgur.com/mCdDgsn.png", text = "Flexible"},
            new payload { imageURL = "http://imgur.com/tPT3ypC", text = "If that were my bed..."},
            new payload { imageURL = "http://i.imgur.com/BmpjzOW.jpg", text = "Black lingerie"},
            new payload { imageURL = "http://i.imgur.com/NXBHat2.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/ZFhlwgt.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/qSaIjo3.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.hottestslutz.com/upload/2014/07/27/20140727015123-05fc42d9.gif", text = "Your hair is fine baby, really [GIF]"},
            new payload { imageURL = "http://i.imgur.com/uOetIaZ.jpg", text = "Hotness"},
            new payload { imageURL = "http://imgur.com/yCu6MUP", text = "Triple Hotness"},
            new payload { imageURL = "http://i.imgur.com/n0sQhej.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/jFJcslB.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/uQLyz1c.jpg", text = "Redhair Lingerie"},
            new payload { imageURL = "http://i.hottestslutz.com/upload/2014/07/27/20140727015135-2d62c6dc.gif", text = "Well, hellooo kitty! [GIF]"},
            new payload { imageURL = "http://i.imgur.com/D80oxsA.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/VPi196h.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/D6cUrra.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/tKCw5PX.png", text = "Hotness"},
            new payload { imageURL = "http://i.hottestslutz.com/upload/2014/07/27/20140727015225-538a0409.gif", text = "Twerking [GIF]"},
            new payload { imageURL = "http://i.imgur.com/ih7Pj0T.png", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/he1op5b.jpg", text = "Hotness"},
            new payload { imageURL = "http://i.imgur.com/BWh8roJ.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.imgur.com/lYsBamU.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.imgur.com/ai7RyIx.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.imgur.com/eC7yOtv.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.imgur.com/R8cUSGx.jpg", text = "Michelle Lewin"},
            new payload { imageURL = "http://i.imgur.com/nLe0Y6J.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.hottestslutz.com/upload/2014/07/27/20140727015324-46b6bcad.gif", text = "Tight latex dress [GIF]"},
            new payload { imageURL = "http://i.imgur.com/nqRlPrY.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.imgur.com/Lb05OFg.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.imgur.com/Ja0CuYx.jpg", text = "Camille Rowe"},
            new payload { imageURL = "http://i.imgur.com/CzISDuI.jpg", text = "Cameron Russell"},
            new payload { imageURL = "http://i.imgur.com/LFN3m8a.jpg", text = "Daily hotness"},
            new payload { imageURL = "http://i.imgur.com/bmOH7YG.jpg", text = "Aline Weber"},
            new payload { imageURL = "http://i.imgur.com/hK2UxLo.jpg", text = "Frida Aasen"},
            new payload { imageURL = "http://imgur.com/a/v5cdI", text = "Anya the Angel (x-post /r/NSFWCostumes)"},
            new payload { imageURL = "http://i.imgur.com/GanYJ3H.jpg", text = "Black Lace"},
            new payload { imageURL = "http://i.imgur.com/jICjJyY.png", text = "no pants"},
            new payload { imageURL = "http://i.imgur.com/eUzat5J.jpg", text = "From above"},
            new payload { imageURL = "http://i.imgur.com/XCW3O.jpg", text = "Candy apple"},
            new payload { imageURL = "http://imgur.com/IBwJhFS", text = "Emily Sears"},
            new payload { imageURL = "http://i.imgur.com/KcOCD.jpg", text = "Pretty cute"},
            new payload { imageURL = "http://i.imgur.com/GN2SyKA.jpg", text = "In the pool"},
            new payload { imageURL = "http://i.imgur.com/lHqjgt4.jpg", text = "Those are fun to play with, no doubt about it"},
            new payload { imageURL = "http://i.imgur.com/YX3KS06.gif", text = "fur cleavage"},
            new payload { imageURL = "http://i.imgur.com/PQy2t8C.png", text = "All that cleavage... (xpost /r/realbrides)"},
            new payload { imageURL = "http://i.imgur.com/PDCCua2.jpg", text = "Fierce"},
            new payload { imageURL = "http://imgur.com/a/2cmVs", text = "Maitland Ward knows it's the season for giving..."},
            new payload { imageURL = "http://i.imgur.com/Zg3oK53.jpg", text = "Needs a bigger shirt!"},
            new payload { imageURL = "http://imgur.com/dF3Ol6X", text = "She's so busty"},
            new payload { imageURL = "http://i.imgur.com/dQJFRl2.gif", text = "Pushing them together"},
            new payload { imageURL = "http://i.imgur.com/vG0o0gW.jpg", text = "Hello there, cap'n!"},
            new payload { imageURL = "http://i.imgur.com/gUclWLz.jpg", text = "That top can barely hold it"},
            new payload { imageURL = "http://i.imgur.com/rm24DkE.jpg", text = "Bent over"},
            new payload { imageURL = "http://i.imgur.com/hzmhH1g.jpg", text = "Sexy Outfit, Sexy Cleavage"},
            new payload { imageURL = "http://imgur.com/9S42BWr", text = "Oh my goodness"},
            new payload { imageURL = "http://i.imgur.com/dpCGhYQ.jpg", text = "Leather bikini"},
            new payload { imageURL = "http://i.imgur.com/8xsJr6U.jpg", text = "Lovely dress"},
            new payload { imageURL = "http://i.imgur.com/lEJv2uQ.jpg", text = "Renaissance Fair"},
            new payload { imageURL = "http://imgur.com/wR5rYoP", text = "About to watch a movie"},
            new payload { imageURL = "http://i.imgur.com/jxOZWGd.jpg", text = "Perfect asian tanline"},
            new payload { imageURL = "http://i.imgur.com/74YVnyv.jpg", text = "Showing some cleavage"},
            new payload { imageURL = "http://i.imgur.com/k7hO64g.jpg", text = "Happy"},
            new payload { imageURL = "http://imgur.com/lJFwz2o", text = "Cleavage. Redhead. Motherfucking Lip Bite. Ugh."},
            new payload { imageURL = "http://i.imgur.com/HTKUlpr.jpg", text = "A little lace for you guys!"},
            new payload { imageURL = "http://imgur.com/YSh5ipA", text = "Enjoy the view, my husband sure did."},
            new payload { imageURL = "http://imgur.com/a/si0qN", text = "A few of my own, hope you enjoy!"},
            new payload { imageURL = "http://imgur.com/5A7QQoT", text = "Massive rack"},
            new payload { imageURL = "http://i.imgur.com/HhkNPcF.jpg", text = "Proper work attire."},
            new payload { imageURL = "http://i.imgur.com/SoS7rIgl.jpg", text = "Welcome to Motorboat City"},
            new payload { imageURL = "http://i.imgur.com/xCiwp4y.jpg", text = "I'll admit I didn't marry her for her cooking skills."},
            new payload { imageURL = "http://imgur.com/BCdrYDa", text = "Sweet cleavage (and midsection)"},
            new payload { imageURL = "http://imgur.com/FJH56oZ", text = "JESUS CHRIST did she go out dressed like this! :)"},
            new payload { imageURL = "http://i.imgur.com/rsCxs8H.jpg", text = "Morning cleavage"},
            new payload { imageURL = "http://imgur.com/RPzCrkr", text = "Cleavage...oh my lord..."},
            new payload { imageURL = "http://imgur.com/a/7ihPX", text = "(F)irst post in this reddit...hope you like!"},
            new payload { imageURL = "http://imgur.com/kPPQ90o", text = "My own asian Laker Girl."},
            new payload { imageURL = "http://imgur.com/6LcLnrS", text = "Cleavage Airlines"},
            new payload { imageURL = "http://imgur.com/JmxlZoi", text = "5' 92lbs, 32C :) [f]"},
            new payload { imageURL = "http://imgur.com/5kI9D27", text = "My asian girlfriend has the greatest cleavage, I shit you not."},
            new payload { imageURL = "http://i.imgur.com/vfN9S.jpg", text = "Green bra"},
            new payload { imageURL = "http://i.imgur.com/K5wUyrD.png", text = "Cleavage at the grocery store"},
            new payload { imageURL = "http://i.imgur.com/NOXssSz.jpg", text = "Lady in red"},
            new payload { imageURL = "http://imgur.com/mgwjVE5", text = "That's a lot of cleavage!"},
            new payload { imageURL = "http://imgur.com/SMd4cO4", text = "Awesome tits"},
            new payload { imageURL = "http://i.imgur.com/6yp9beD.jpg", text = "Stunner in see thru top"},
            new payload { imageURL = "http://i.imgur.com/r3LbxQN.jpg", text = "Getting busy in a bathroom stall."},
            new payload { imageURL = "http://i.imgur.com/4BjrLvl.jpg", text = "How's this for cleavage?"},
            new payload { imageURL = "http://imgur.com/DbyMppW", text = "Polka-Dots"},
            new payload { imageURL = "http://i.imgur.com/8GWtlaa.jpg", text = "Some great tits."},
            new payload { imageURL = "http://i.imgur.com/Byzbi9m.jpg", text = "My jaw is somewhere on her bed"},
            new payload { imageURL = "http://i.imgur.com/mR4oJpt.jpg", text = "Cleavage roaming the streets"},
            new payload { imageURL = "http://i.imgur.com/sgKRzHI.jpg", text = "Woah."},
            new payload { imageURL = "http://imgur.com/nIsQehI", text = "We only see a bit, but my god… this cleavage must go deep"},
            new payload { imageURL = "http://i.imgur.com/25FPzA6.jpg", text = "on her side"},
            new payload { imageURL = "http://i.imgur.com/SNXKM0p.jpg", text = "No Bra"},
            new payload { imageURL = "http://i.imgur.com/rm24DkE.jpg", text = "Bent over"},
            new payload { imageURL = "http://i.imgur.com/PwbVUiU.gif", text = "Batgirl"},
            new payload { imageURL = "http://i.imgur.com/yHB7p6M.jpg", text = "Black dress (x-post from /r/tightdresses)"},
            new payload { imageURL = "http://imgur.com/6bkzbtN", text = "Hey r/cleavage - is this overkill?"},
            new payload { imageURL = "http://i.imgur.com/CzUvQKN.jpg", text = "checking in"},
            new payload { imageURL = "http://i.imgur.com/jJED5W4.jpg", text = "The perfect rack to stick something in between there."},
            new payload { imageURL = "http://i.imgur.com/jsqFLko.jpg", text = "Grey tank top"},
            new payload { imageURL = "http://i.imgur.com/7LLaAxn.jpg", text = "Busty brunette"},
            new payload { imageURL = "http://i.imgur.com/74YVnyv.jpg", text = "Showing some cleavage"},
            new payload { imageURL = "http://i.imgur.com/AO50Vyk.jpg", text = "Amazing airplane cleavage [xpost /r/Titties]"},
            new payload { imageURL = "http://i.imgur.com/caj8GEk.jpg", text = "Kate Upton leaning to one side"},
            new payload { imageURL = "https://pbs.twimg.com/media/BSyIykiIMAEq-v2.jpg", text = "Tori black"},
            new payload { imageURL = "http://i.imgur.com/aswatsy.jpg", text = "Now that is what you call cleavage"},
            new payload { imageURL = "http://i.imgur.com/1fGpcI8.jpg", text = "Dark hair, pale skin"},
            new payload { imageURL = "http://imgur.com/1OZjVR6", text = "Ready For Bed"},
            new payload { imageURL = "http://i.imgur.com/Ojyp9by.jpg", text = "Going to the Renaissance fair."},
            new payload { imageURL = "http://i.imgur.com/NLldDHQ.jpg", text = "Shirt fits just right"},
            new payload { imageURL = "http://i.imgur.com/b4rtTla.jpg", text = "Cleavage in dress"},
            new payload { imageURL = "http://i.imgur.com/HmWIYYr.jpg", text = "Simply Beautiful"},
            new payload { imageURL = "http://i.imgur.com/ooKkh0F.jpg", text = "Not sure if that is a laptop or not"},
            new payload { imageURL = "http://i.imgur.com/pGwg6sa.jpg", text = "Below."},
            new payload { imageURL = "http://i.imgur.com/y9iA8Ps.jpg", text = "White tank top over a pink bra."},
            new payload { imageURL = "http://i.imgur.com/hAeGL.jpg", text = "Very nice cleavage"},
            new payload { imageURL = "http://i.imgur.com/Hf1RsJ5.jpg", text = "Almost"},
            new payload { imageURL = "http://i.imgur.com/tIIsLhX.jpg", text = "Nice Glasses"},
            new payload { imageURL = "http://i.imgur.com/vDBVjgR.jpg", text = "Nice shape"},
            new payload { imageURL = "http://i.imgur.com/ffDt5EU.jpg", text = "Do you like my thigh highs? (X-post r/mycleavage)"},
            new payload { imageURL = "http://i.imgur.com/3QdQKmf.jpg", text = "incredible blonde with glasses"},
            new payload { imageURL = "http://i.imgur.com/mLNHsYh.jpg", text = "Blonde in White"},
            new payload { imageURL = "http://i.imgur.com/vOGz8ZE.jpg", text = "Unzipped just enough to tease."},
            new payload { imageURL = "http://i.imgur.com/ZAHp8zm.jpg", text = "Pretty"},
            new payload { imageURL = "http://i.imgur.com/4qpXRbp.jpg", text = "Just a little thick"},
            new payload { imageURL = "http://i.imgur.com/FGUIU5P.gif", text = "light little shake"},
            new payload { imageURL = "http://i.imgur.com/BMrHeNI.jpg", text = "swedish girl"},
            new payload { imageURL = "http://i.imgur.com/0EYVHap.jpg", text = "Black vest top"},
            new payload { imageURL = "http://i.imgur.com/4MNX8P4.jpg", text = "My Cup O' Tea"},
            new payload { imageURL = "http://i.imgur.com/JQv9I.jpg", text = "What would you like?"},
            new payload { imageURL = "http://i.imgur.com/9MQGfmX.jpg", text = "Scrumptious"},
            new payload { imageURL = "http://i.imgur.com/qnwnnPc.jpg", text = "Apparently, you guys like cleavage. May I?"},
            new payload { imageURL = "http://i.imgur.com/R6AXRTG.jpg", text = "Hot Bartender"},
            new payload { imageURL = "http://i.imgur.com/KNaf2pI.jpg", text = "U neck??"},
            new payload { imageURL = "http://imgur.com/YoMPwmk", text = "Cleavage Gif"},
            new payload { imageURL = "http://i.imgur.com/6aqRNO5.jpg", text = "Buxom Brunettes"},
            new payload { imageURL = "http://imgur.com/fYBh0JL", text = "Unbuttoned"},
            new payload { imageURL = "http://imgur.com/a/PXGe5", text = "Workout cleavage"},
            new payload { imageURL = "http://i.imgur.com/JP7YafH.jpg", text = "Hailey Leigh"},
            new payload { imageURL = "http://imgur.com/ahJFKHB", text = "Just a little taste ;)"},
            new payload { imageURL = "http://i.imgur.com/y2OKmNn.jpg", text = "Black top"},
            new payload { imageURL = "http://i.imgur.com/pcRgKOR.jpg", text = "Fairly epic"},
            new payload { imageURL = "http://i.imgur.com/ZoMSH.jpg", text = "Barely contained"},
            new payload { imageURL = "http://i.imgur.com/rM9kqsb.jpg", text = "Epic"},
            new payload { imageURL = "http://imgur.com/u1uxNtv", text = "So Damn Big"},
            new payload { imageURL = "http://i.imgur.com/n3s58AJ.jpg", text = "Deep neck line."},
            new payload { imageURL = "http://i.imgur.com/rPZBKyk.jpg", text = "Eye Contact Test"},
            new payload { imageURL = "http://i.imgur.com/yVbzMd8.jpg", text = "Yellow top"},
            new payload { imageURL = "http://imgur.com/a/SSNFc", text = "I was told I should post here. So here are two of me, for you."},
            new payload { imageURL = "http://i.imgur.com/NRvYMyi.jpg", text = "Cleavage with a smile"},
            new payload { imageURL = "http://imgur.com/a/SEDMa", text = "Enjoy this album"},
            new payload { imageURL = "http://i.imgur.com/QpGmeGE.png", text = "Unkwown (another in comments)"},
            new payload { imageURL = "http://i.imgur.com/3Z2mz44.jpg", text = "Orange bikini"},
            new payload { imageURL = "http://i.imgur.com/sDKFndl.jpg", text = "How about a little tug?"},
            new payload { imageURL = "http://i.imgur.com/Rgp3grV.jpg", text = "Barely Contained"},
            new payload { imageURL = "http://i.imgur.com/pLKQ1Rj.jpg", text = "August Ames"},
            new payload { imageURL = "http://41.media.tumblr.com/ee0c610b93d0cdb62d63da71426dbdd9/tumblr_moyo4d4XPR1rpqy2eo1_500.jpg", text = "how about a towel"},
            new payload { imageURL = "http://imgur.com/a/sVOD5", text = "Cute Amateur Blonde"},
            new payload { imageURL = "http://imgur.com/Aj2uubG", text = "Lucy Morey never disappoints"},
            new payload { imageURL = "http://i.imgur.com/Bffyt0q.jpg", text = "Scarlett Johansson (cross post from gentlemanboners)"},
            new payload { imageURL = "http://imgur.com/zFWeieY", text = "Masha"},
            new payload { imageURL = "http://imgur.com/a/mSuKq", text = "My tiny green shorts"},
            new payload { imageURL = "http://imgur.com/a/78Duy", text = "Cheerleader"},
            new payload { imageURL = "http://i.imgur.com/UwFkzdG.jpg", text = "cute blue selfie"},
            new payload { imageURL = "http://i.imgur.com/1dMtF27.jpg", text = "laundry day"},
            new payload { imageURL = "http://i.imgur.com/OhDUQ5z.jpg", text = "splitting"},
            new payload { imageURL = "http://i.imgur.com/zvlVXMG.jpg", text = "two pair"},
            new payload { imageURL = "http://i.imgur.com/FSUkyxr.jpg", text = "The hottest 40-year-old on this side of the Mississippi..."},
            new payload { imageURL = "http://i.imgur.com/crvYbYy.jpg", text = "White girl booty"},
            new payload { imageURL = "http://i.imgur.com/DCuDqrA.gif", text = "Clockwise"},
            new payload { imageURL = "http://i.imgur.com/RmzRVxm.jpg", text = "cut offs"},
            new payload { imageURL = "http://i.imgur.com/oEsxtpu.jpg", text = "Do you guys approve o[f] self posts?"},
            new payload { imageURL = "http://i.imgur.com/fTzo1et.jpg", text = "her shorts belong on a pole"},
            new payload { imageURL = "http://imgur.com/Ef1hP2S", text = "Only acceptable form of jean shorts"},
            new payload { imageURL = "http://i.imgur.com/jZ2etZJ.gif", text = "Laura Vandervoort [gif]"},
            new payload { imageURL = "http://i.imgur.com/YzMbywX.jpg", text = "little yellow shorts"},
            new payload { imageURL = "http://i.imgur.com/eAVW1TQ.gif", text = "Turn around"},
            new payload { imageURL = "http://i.imgur.com/SwbfebT.jpg", text = "her shorts get my upvote"},
            new payload { imageURL = "http://i.imgur.com/rKi1FSi.jpg", text = "pikachu"},
            new payload { imageURL = "http://i.imgur.com/40BeMF6.jpg", text = "rodeo night"},
            new payload { imageURL = "http://i.imgur.com/zu0D8ju.jpg", text = "do you pull them down, or push to the side?"},
            new payload { imageURL = "http://imgur.com/a/XItGQ", text = "Our Queen Remy"},
            new payload { imageURL = "http://i.imgur.com/x0T81mX.jpg", text = "better than the game"},
            new payload { imageURL = "http://imgur.com/teoYQXF", text = "Going for a run"},
            new payload { imageURL = "http://i.imgur.com/5QDIp8i.jpg", text = "team colors"},
            new payload { imageURL = "http://imgur.com/PktU7oZ", text = "Karolina Debczynska"},
            new payload { imageURL = "http://i.imgur.com/iq7JsSC.jpg", text = "tight blue shorts"},
            new payload { imageURL = "http://www.gfycat.com/BronzeAlienatedHagfish", text = "10/10 Would Spot for Her Even Though It's Not Necessary [GIF]"},
            new payload { imageURL = "http://i.imgur.com/SUGeOx1.jpg", text = "Bedside"},
            new payload { imageURL = "http://i.imgur.com/0duToSt.jpg", text = "i should be a yoga instructor"},
            new payload { imageURL = "http://i.imgur.com/l768jtc.jpg", text = "Bike goodness"},
            new payload { imageURL = "http://i.imgur.com/nxrCNGF.jpg", text = "Candice Swanepoel"},
            new payload { imageURL = "http://i.imgur.com/7195PwW.jpg", text = "White girl (x-post /r/ass)"},
            new payload { imageURL = "http://i.imgur.com/X95OJzC.jpg", text = "Tight gym shorts"},
            new payload { imageURL = "http://i.imgur.com/9JJWdfZ.jpg", text = "tied up"},
            new payload { imageURL = "http://i.imgur.com/Yf8BuKv.jpg", text = "oh my god becky"},
            new payload { imageURL = "http://i.imgur.com/EnFTWnO.jpg", text = "Tight"},
            new payload { imageURL = "http://i.imgur.com/URS1q.jpg", text = "Flowery"},
            new payload { imageURL = "http://i.imgur.com/Qz0wcPu.jpg", text = "viewing the scenery"},
            new payload { imageURL = "http://i.imgur.com/8VJFvwx.jpg", text = "Sexy Booty"},
            new payload { imageURL = "http://i.imgur.com/SoFhONi.jpg", text = "Awesome ass for it"},
            new payload { imageURL = "http://i.imgur.com/3j75IZH.jpg", text = "Ellie Gonsalves"},
            new payload { imageURL = "http://i.imgur.com/fpPpOxD.jpg", text = "assume the position"},
            new payload { imageURL = "http://i.imgur.com/hqjHjWl.jpg", text = "cheeky selfie"},
            new payload { imageURL = "http://i.imgur.com/oCEkcuN.png", text = "Does this belong here? I'm guessing girl on the left does"},
            new payload { imageURL = "http://i.imgur.com/7KT0oAf.jpg", text = "dropped her shorts"},
            new payload { imageURL = "http://i.imgur.com/0rUm27Z.jpg", text = "hallway model"},
            new payload { imageURL = "http://i.imgur.com/AkK7q1o.jpg", text = "daniella"},
            new payload { imageURL = "http://i.imgur.com/y3VS4mH.jpg", text = "my wife does this all the time and wonders why her shorts are constantly being pulled down"},
            new payload { imageURL = "http://imgur.com/zMyLo9n", text = "Nice view"},
        };


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }   

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]incomingSlack message)
        {

            Random rolledInt = new Random();

            var item = paydirt[rolledInt.Next(paydirt.Length)];

            outgoingSlack result = new outgoingSlack { text = item.text + " " + item.imageURL };

            return Ok(result);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
