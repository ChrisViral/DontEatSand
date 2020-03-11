using System;
using System.Collections.Generic;
using UnityEngine;

namespace DontEatSand.Utils
{
    /// <summary>
    /// Collection of 949 Color objects, taken from the XKCD Colour Survey
    /// Explanation:      https://blog.xkcd.com/2010/05/03/color-survey-results/
    /// Colours preview:  https://xkcd.com/color/rgb/
    /// Parsed from this: http://forum.unity3d.com/threads/xkcd-colors-in-unity.85896/
    /// Using this tool:  https://github.com/StupidChris/XKCDColourParser
    /// </summary>
    public static class XKCDColours
    {
        #region Colours
        /// <summary>
        /// A formatted XKCD survey colour (0.8980392, 0, 0)
        /// </summary>
        public static Color Red { get; } = new Color(0.8980392f, 0f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5176471, 0, 0)
        /// </summary>
        public static Color DarkRed { get; } = new Color(0.5176471f, 0f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2941177, 0.003921569, 0.003921569)
        /// </summary>
        public static Color DriedBlood { get; } = new Color(0.2941177f, 0.003921569f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7333333, 0.2470588, 0.2470588)
        /// </summary>
        public static Color DullRed { get; } = new Color(0.7333333f, 0.2470588f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.4823529, 0.4862745)
        /// </summary>
        public static Color SalmonPink { get; } = new Color(0.9960784f, 0.4823529f, 0.4862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0, 0.007843138)
        /// </summary>
        public static Color FireEngineRed { get; } = new Color(0.9960784f, 0f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4666667, 0, 0.003921569)
        /// </summary>
        public static Color Blood { get; } = new Color(0.4666667f, 0f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.3803922, 0.3882353)
        /// </summary>
        public static Color CoralPink { get; } = new Color(1f, 0.3803922f, 0.3882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5960785, 0, 0.007843138)
        /// </summary>
        public static Color BloodRed { get; } = new Color(0.5960785f, 0f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.2784314, 0.2980392)
        /// </summary>
        public static Color LightRed { get; } = new Color(1f, 0.2784314f, 0.2980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6627451, 0.01176471, 0.03137255)
        /// </summary>
        public static Color DarkishRed { get; } = new Color(0.6627451f, 0.01176471f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.827451, 0.2862745, 0.3058824)
        /// </summary>
        public static Color FadedRed { get; } = new Color(0.827451f, 0.2862745f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0, 0.05098039)
        /// </summary>
        public static Color BrightRed { get; } = new Color(1f, 0f, 0.05098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7254902, 0.282353, 0.3058824)
        /// </summary>
        public static Color DustyRed { get; } = new Color(0.7254902f, 0.282353f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7921569, 0.4823529, 0.5019608)
        /// </summary>
        public static Color DirtyPink { get; } = new Color(0.7921569f, 0.4823529f, 0.5019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.7568628, 0.772549)
        /// </summary>
        public static Color PaleRose { get; } = new Color(0.9921569f, 0.7568628f, 0.772549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.509804, 0.5490196)
        /// </summary>
        public static Color BlushPink { get; } = new Color(0.9960784f, 0.509804f, 0.5490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7529412, 0.4509804, 0.4784314)
        /// </summary>
        public static Color DustyRose { get; } = new Color(0.7529412f, 0.4509804f, 0.4784314f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.772549, 0.7960784)
        /// </summary>
        public static Color LightRose { get; } = new Color(1f, 0.772549f, 0.7960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.2745098, 0.3490196)
        /// </summary>
        public static Color Watermelon { get; } = new Color(0.9921569f, 0.2745098f, 0.3490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5490196, 0, 0.05882353)
        /// </summary>
        public static Color Crimson { get; } = new Color(0.5490196f, 0f, 0.05882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4039216, 0.227451, 0.2470588)
        /// </summary>
        public static Color PurpleBrown { get; } = new Color(0.4039216f, 0.227451f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.5529412, 0.5803922)
        /// </summary>
        public static Color GreyishPink { get; } = new Color(0.7843137f, 0.5529412f, 0.5803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4196078, 0.2588235, 0.2784314)
        /// </summary>
        public static Color PurplishBrown { get; } = new Color(0.4196078f, 0.2588235f, 0.2784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9843137, 0.1607843, 0.2627451)
        /// </summary>
        public static Color Strawberry { get; } = new Color(0.9843137f, 0.1607843f, 0.2627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7450981, 0.003921569, 0.09803922)
        /// </summary>
        public static Color Scarlet { get; } = new Color(0.7450981f, 0.003921569f, 0.09803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 0.007843138, 0.08627451)
        /// </summary>
        public static Color Carmine { get; } = new Color(0.6156863f, 0.007843138f, 0.08627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.1843137, 0.2901961)
        /// </summary>
        public static Color LightishRed { get; } = new Color(0.9960784f, 0.1843137f, 0.2901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2352941, 0, 0.03137255)
        /// </summary>
        public static Color DarkMaroon { get; } = new Color(0.2352941f, 0f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8352941, 0.5411765, 0.5803922)
        /// </summary>
        public static Color DustyPink { get; } = new Color(0.8352941f, 0.5411765f, 0.5803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7294118, 0.4078431, 0.4509804)
        /// </summary>
        public static Color DuskyRose { get; } = new Color(0.7294118f, 0.4078431f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.4980392, 0.5372549)
        /// </summary>
        public static Color OldRose { get; } = new Color(0.7843137f, 0.4980392f, 0.5372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.1490196, 0.2784314)
        /// </summary>
        public static Color PinkyRed { get; } = new Color(0.9882353f, 0.1490196f, 0.2784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9686275, 0.007843138, 0.1647059)
        /// </summary>
        public static Color CherryRed { get; } = new Color(0.9686275f, 0.007843138f, 0.1647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6352941, 0.282353, 0.3411765)
        /// </summary>
        public static Color LightMaroon { get; } = new Color(0.6352941f, 0.282353f, 0.3411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.4745098, 0.5607843)
        /// </summary>
        public static Color Carnation { get; } = new Color(0.9921569f, 0.4745098f, 0.5607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7803922, 0.4745098, 0.5254902)
        /// </summary>
        public static Color OldPink { get; } = new Color(0.7803922f, 0.4745098f, 0.5254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9686275, 0.5294118, 0.6039216)
        /// </summary>
        public static Color RosePink { get; } = new Color(0.9686275f, 0.5294118f, 0.6039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8039216, 0.4588235, 0.5176471)
        /// </summary>
        public static Color UglyPink { get; } = new Color(0.8039216f, 0.4588235f, 0.5176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8117647, 0.3843137, 0.4588235)
        /// </summary>
        public static Color Rose { get; } = new Color(0.8117647f, 0.3843137f, 0.4588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8313726, 0.4156863, 0.4941176)
        /// </summary>
        public static Color Pinkish { get; } = new Color(0.8313726f, 0.4156863f, 0.4941176f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.172549, 0.3294118)
        /// </summary>
        public static Color ReddishPink { get; } = new Color(0.9960784f, 0.172549f, 0.3294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7098039, 0.282353, 0.3647059)
        /// </summary>
        public static Color DarkRose { get; } = new Color(0.7098039f, 0.282353f, 0.3647059f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.02745098, 0.227451)
        /// </summary>
        public static Color NeonRed { get; } = new Color(1f, 0.02745098f, 0.227451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9803922, 0.1647059, 0.3333333)
        /// </summary>
        public static Color RedPink { get; } = new Color(0.9803922f, 0.1647059f, 0.3333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8, 0.4784314, 0.5450981)
        /// </summary>
        public static Color DuskyPink { get; } = new Color(0.8f, 0.4784314f, 0.5450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.6901961, 0.7529412)
        /// </summary>
        public static Color SoftPink { get; } = new Color(0.9921569f, 0.6901961f, 0.7529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7647059, 0.5647059, 0.6078432)
        /// </summary>
        public static Color GreyPink { get; } = new Color(0.7647059f, 0.5647059f, 0.6078432f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4078431, 0, 0.09411765)
        /// </summary>
        public static Color Claret { get; } = new Color(0.4078431f, 0f, 0.09411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4627451, 0.2588235, 0.3058824)
        /// </summary>
        public static Color BrownishPurple { get; } = new Color(0.4627451f, 0.2588235f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8705882, 0.6156863, 0.6745098)
        /// </summary>
        public static Color FadedPink { get; } = new Color(0.8705882f, 0.6156863f, 0.6745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7529412, 0.007843138, 0.1843137)
        /// </summary>
        public static Color LipstickRed { get; } = new Color(0.7529412f, 0.007843138f, 0.1843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8117647, 0.007843138, 0.2039216)
        /// </summary>
        public static Color Cherry { get; } = new Color(0.8117647f, 0.007843138f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.945098, 0.04705882, 0.2705882)
        /// </summary>
        public static Color PinkishRed { get; } = new Color(0.945098f, 0.04705882f, 0.2705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7803922, 0.2784314, 0.4039216)
        /// </summary>
        public static Color DeepRose { get; } = new Color(0.7803922f, 0.2784314f, 0.4039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.5254902, 0.6431373)
        /// </summary>
        public static Color Rosa { get; } = new Color(0.9960784f, 0.5254902f, 0.6431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.254902, 0.3568628)
        /// </summary>
        public static Color LightBurgundy { get; } = new Color(0.6588235f, 0.254902f, 0.3568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6705883, 0.07058824, 0.2235294)
        /// </summary>
        public static Color Rouge { get; } = new Color(0.6705883f, 0.07058824f, 0.2235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9058824, 0.5568628, 0.6470588)
        /// </summary>
        public static Color PigPink { get; } = new Color(0.9058824f, 0.5568628f, 0.6470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.682353, 0.4431373, 0.5058824)
        /// </summary>
        public static Color Mauve { get; } = new Color(0.682353f, 0.4431373f, 0.5058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9843137, 0.3333333, 0.5058824)
        /// </summary>
        public static Color WarmPink { get; } = new Color(0.9843137f, 0.3333333f, 0.5058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4823529, 0.01176471, 0.1372549)
        /// </summary>
        public static Color WineRed { get; } = new Color(0.4823529f, 0.01176471f, 0.1372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9647059, 0.4078431, 0.5568628)
        /// </summary>
        public static Color RosyPink { get; } = new Color(0.9647059f, 0.4078431f, 0.5568628f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.8117647, 0.8627451)
        /// </summary>
        public static Color PalePink { get; } = new Color(1f, 0.8117647f, 0.8627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8196079, 0.4627451, 0.5607843)
        /// </summary>
        public static Color MutedPink { get; } = new Color(0.8196079f, 0.4627451f, 0.5607843f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.7294118, 0.8039216)
        /// </summary>
        public static Color PastelPink { get; } = new Color(1f, 0.7294118f, 0.8039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8352941, 0.09019608, 0.3058824)
        /// </summary>
        public static Color Lipstick { get; } = new Color(0.8352941f, 0.09019608f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8352941, 0.5254902, 0.6156863)
        /// </summary>
        public static Color DullPink { get; } = new Color(0.8352941f, 0.5254902f, 0.6156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0.254902, 0.4196078)
        /// </summary>
        public static Color DarkPink { get; } = new Color(0.7960784f, 0.254902f, 0.4196078f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.8196079, 0.8745098)
        /// </summary>
        public static Color LightPink { get; } = new Color(1f, 0.8196079f, 0.8745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.5254902, 0.6666667)
        /// </summary>
        public static Color Pinky { get; } = new Color(0.9882353f, 0.5254902f, 0.6666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9607843, 0.01960784, 0.3098039)
        /// </summary>
        public static Color PinkRed { get; } = new Color(0.9607843f, 0.01960784f, 0.3098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7450981, 0.003921569, 0.2352941)
        /// </summary>
        public static Color RoseRed { get; } = new Color(0.7450981f, 0.003921569f, 0.2352941f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.4980392, 0.654902)
        /// </summary>
        public static Color CarnationPink { get; } = new Color(1f, 0.4980392f, 0.654902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7607843, 0.572549, 0.6313726)
        /// </summary>
        public static Color LightMauve { get; } = new Color(0.7607843f, 0.572549f, 0.6313726f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.7176471, 0.8078431)
        /// </summary>
        public static Color BabyPink { get; } = new Color(1f, 0.7176471f, 0.8078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0, 0.1294118)
        /// </summary>
        public static Color Maroon { get; } = new Color(0.3960784f, 0f, 0.1294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7921569, 0.003921569, 0.2784314)
        /// </summary>
        public static Color Ruby { get; } = new Color(0.7921569f, 0.003921569f, 0.2784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4823529, 0, 0.172549)
        /// </summary>
        public static Color Bordeaux { get; } = new Color(0.4823529f, 0f, 0.172549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3803922, 0, 0.1372549)
        /// </summary>
        public static Color Burgundy { get; } = new Color(0.3803922f, 0f, 0.1372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9529412, 0.3803922, 0.5882353)
        /// </summary>
        public static Color MediumPink { get; } = new Color(0.9529412f, 0.3803922f, 0.5882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6196079, 0, 0.227451)
        /// </summary>
        public static Color Cranberry { get; } = new Color(0.6196079f, 0f, 0.227451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5490196, 0, 0.2039216)
        /// </summary>
        public static Color RedWine { get; } = new Color(0.5490196f, 0f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.854902, 0.2745098, 0.4901961)
        /// </summary>
        public static Color DarkishPink { get; } = new Color(0.854902f, 0.2745098f, 0.4901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5294118, 0.2980392, 0.3843137)
        /// </summary>
        public static Color DarkMauve { get; } = new Color(0.5294118f, 0.2980392f, 0.3843137f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6980392, 0.8156863)
        /// </summary>
        public static Color PowderPink { get; } = new Color(1f, 0.6980392f, 0.8156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6901961, 0.01960784, 0.2941177)
        /// </summary>
        public static Color PurplishRed { get; } = new Color(0.6901961f, 0.01960784f, 0.2941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8705882, 0.04705882, 0.3843137)
        /// </summary>
        public static Color Cerise { get; } = new Color(0.8705882f, 0.04705882f, 0.3843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6901961, 0.003921569, 0.2862745)
        /// </summary>
        public static Color Raspberry { get; } = new Color(0.6901961f, 0.003921569f, 0.2862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6, 0.05882353, 0.2941177)
        /// </summary>
        public static Color Berry { get; } = new Color(0.6f, 0.05882353f, 0.2941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6, 0.003921569, 0.2784314)
        /// </summary>
        public static Color PurpleRed { get; } = new Color(0.6f, 0.003921569f, 0.2784314f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.4117647, 0.6862745)
        /// </summary>
        public static Color BubbleGumPink { get; } = new Color(1f, 0.4117647f, 0.6862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8509804, 0.003921569, 0.4)
        /// </summary>
        public static Color DarkHotPink { get; } = new Color(0.8509804f, 0.003921569f, 0.4f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0.003921569, 0.3843137)
        /// </summary>
        public static Color DeepPink { get; } = new Color(0.7960784f, 0.003921569f, 0.3843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5019608, 0.003921569, 0.2470588)
        /// </summary>
        public static Color Wine { get; } = new Color(0.5019608f, 0.003921569f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4509804, 0, 0.2235294)
        /// </summary>
        public static Color Merlot { get; } = new Color(0.4509804f, 0f, 0.2235294f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.4235294, 0.7098039)
        /// </summary>
        public static Color Bubblegum { get; } = new Color(1f, 0.4235294f, 0.7098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.572549, 0.03921569, 0.3058824)
        /// </summary>
        public static Color Mulberry { get; } = new Color(0.572549f, 0.03921569f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.5058824, 0.7529412)
        /// </summary>
        public static Color Pink { get; } = new Color(1f, 0.5058824f, 0.7529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6470588, 0, 0.3333333)
        /// </summary>
        public static Color VioletRed { get; } = new Color(0.6470588f, 0f, 0.3333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.2745098, 0.6470588)
        /// </summary>
        public static Color BarbiePink { get; } = new Color(0.9960784f, 0.2745098f, 0.6470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.509804, 0.02745098, 0.2784314)
        /// </summary>
        public static Color RedPurple { get; } = new Color(0.509804f, 0.02745098f, 0.2784314f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.02745098, 0.5372549)
        /// </summary>
        public static Color StrongPink { get; } = new Color(1f, 0.02745098f, 0.5372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5686275, 0.03529412, 0.3176471)
        /// </summary>
        public static Color ReddishPurple { get; } = new Color(0.5686275f, 0.03529412f, 0.3176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 0.02745098, 0.3490196)
        /// </summary>
        public static Color DarkFuchsia { get; } = new Color(0.6156863f, 0.02745098f, 0.3490196f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.007843138, 0.5529412)
        /// </summary>
        public static Color HotPink { get; } = new Color(1f, 0.007843138f, 0.5529412f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.01568628, 0.5647059)
        /// </summary>
        public static Color ElectricPink { get; } = new Color(1f, 0.01568628f, 0.5647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.627451, 0.007843138, 0.3607843)
        /// </summary>
        public static Color DeepMagenta { get; } = new Color(0.627451f, 0.007843138f, 0.3607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5882353, 0, 0.3372549)
        /// </summary>
        public static Color DarkMagenta { get; } = new Color(0.5882353f, 0f, 0.3372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.5137255, 0.8)
        /// </summary>
        public static Color BubblegumPink { get; } = new Color(0.9960784f, 0.5137255f, 0.8f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.003921569, 0.6039216)
        /// </summary>
        public static Color NeonPink { get; } = new Color(0.9960784f, 0.003921569f, 0.6039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7607843, 0, 0.4705882)
        /// </summary>
        public static Color Magenta { get; } = new Color(0.7607843f, 0f, 0.4705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8431373, 0.4039216, 0.6784314)
        /// </summary>
        public static Color PaleMagenta { get; } = new Color(0.8431373f, 0.4039216f, 0.6784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 0.3411765, 0.5137255)
        /// </summary>
        public static Color LightPlum { get; } = new Color(0.6156863f, 0.3411765f, 0.5137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.007843138, 0.6352941)
        /// </summary>
        public static Color ShockingPink { get; } = new Color(0.9960784f, 0.007843138f, 0.6352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6196079, 0.003921569, 0.4078431)
        /// </summary>
        public static Color RedViolet { get; } = new Color(0.6196079f, 0.003921569f, 0.4078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4509804, 0.2901961, 0.3960784)
        /// </summary>
        public static Color DirtyPurple { get; } = new Color(0.4509804f, 0.2901961f, 0.3960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4588235, 0.03137255, 0.3176471)
        /// </summary>
        public static Color Velvet { get; } = new Color(0.4588235f, 0.03137255f, 0.3176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.345098, 0.05882353, 0.254902)
        /// </summary>
        public static Color Plum { get; } = new Color(0.345098f, 0.05882353f, 0.254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2470588, 0.003921569, 0.172549)
        /// </summary>
        public static Color DarkPlum { get; } = new Color(0.2470588f, 0.003921569f, 0.172549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.003921569, 0.6941177)
        /// </summary>
        public static Color BrightPink { get; } = new Color(0.9960784f, 0.003921569f, 0.6941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5372549, 0.3568628, 0.4823529)
        /// </summary>
        public static Color DuskyPurple { get; } = new Color(0.5372549f, 0.3568628f, 0.4823529f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8078431, 0.3647059, 0.682353)
        /// </summary>
        public static Color PurplishPink { get; } = new Color(0.8078431f, 0.3647059f, 0.682353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4470588, 0, 0.345098)
        /// </summary>
        public static Color RichPurple { get; } = new Color(0.4470588f, 0f, 0.345098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4941176, 0.2509804, 0.4431373)
        /// </summary>
        public static Color Bruise { get; } = new Color(0.4941176f, 0.2509804f, 0.4431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4235294, 0.2039216, 0.3803922)
        /// </summary>
        public static Color Grape { get; } = new Color(0.4235294f, 0.2039216f, 0.3803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9607843, 0.01568628, 0.7882353)
        /// </summary>
        public static Color HotMagenta { get; } = new Color(0.9607843f, 0.01568628f, 0.7882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2392157, 0.02745098, 0.2039216)
        /// </summary>
        public static Color Aubergine { get; } = new Color(0.2392157f, 0.02745098f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5960785, 0.3372549, 0.5529412)
        /// </summary>
        public static Color Purpleish { get; } = new Color(0.5960785f, 0.3372549f, 0.5529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3647059, 0.07843138, 0.3176471)
        /// </summary>
        public static Color GrapePurple { get; } = new Color(0.3647059f, 0.07843138f, 0.3176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8745098, 0.3058824, 0.7843137)
        /// </summary>
        public static Color PurpleishPink { get; } = new Color(0.8745098f, 0.3058824f, 0.7843137f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.3882353, 0.9137255)
        /// </summary>
        public static Color CandyPink { get; } = new Color(1f, 0.3882353f, 0.9137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5176471, 0.3490196, 0.4941176)
        /// </summary>
        public static Color DullPurple { get; } = new Color(0.5176471f, 0.3490196f, 0.4941176f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5803922, 0.3372549, 0.5490196)
        /// </summary>
        public static Color Purplish { get; } = new Color(0.5803922f, 0.3372549f, 0.5490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.2352941, 0.7254902)
        /// </summary>
        public static Color PurpleyPink { get; } = new Color(0.7843137f, 0.2352941f, 0.7254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.5254902, 0.6588235)
        /// </summary>
        public static Color DustyLavender { get; } = new Color(0.6745098f, 0.5254902f, 0.6588235f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.03137255, 0.9098039)
        /// </summary>
        public static Color BrightMagenta { get; } = new Color(1f, 0.03137255f, 0.9098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9294118, 0.05098039, 0.8509804)
        /// </summary>
        public static Color Fuchsia { get; } = new Color(0.9294118f, 0.05098039f, 0.8509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7882353, 0.2980392, 0.7450981)
        /// </summary>
        public static Color PinkyPurple { get; } = new Color(0.7882353f, 0.2980392f, 0.7450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9411765, 0.4588235, 0.9019608)
        /// </summary>
        public static Color PurplyPink { get; } = new Color(0.9411765f, 0.4588235f, 0.9019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8666667, 0.5215687, 0.8431373)
        /// </summary>
        public static Color LavenderPink { get; } = new Color(0.8666667f, 0.5215687f, 0.8431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2196078, 0.03137255, 0.2078431)
        /// </summary>
        public static Color Eggplant { get; } = new Color(0.2196078f, 0.03137255f, 0.2078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5372549, 0.2705882, 0.5215687)
        /// </summary>
        public static Color LightEggplant { get; } = new Color(0.5372549f, 0.2705882f, 0.5215687f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5843138, 0.1803922, 0.5607843)
        /// </summary>
        public static Color WarmPurple { get; } = new Color(0.5843138f, 0.1803922f, 0.5607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.627451, 0.01568628, 0.5960785)
        /// </summary>
        public static Color BarneyPurple { get; } = new Color(0.627451f, 0.01568628f, 0.5960785f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8784314, 0.2470588, 0.8470588)
        /// </summary>
        public static Color PurplePink { get; } = new Color(0.8784314f, 0.2470588f, 0.8470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.4588235, 0.7686275)
        /// </summary>
        public static Color Orchid { get; } = new Color(0.7843137f, 0.4588235f, 0.7686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.8156863, 0.9882353)
        /// </summary>
        public static Color PaleMauve { get; } = new Color(0.9960784f, 0.8156863f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5254902, 0.4352941, 0.5215687)
        /// </summary>
        public static Color PurpleGrey { get; } = new Color(0.5254902f, 0.4352941f, 0.5215687f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6431373, 0.2588235, 0.627451)
        /// </summary>
        public static Color UglyPurple { get; } = new Color(0.6431373f, 0.2588235f, 0.627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9372549, 0.1137255, 0.9058824)
        /// </summary>
        public static Color Pink_Purple { get; } = new Color(0.9372549f, 0.1137255f, 0.9058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2627451, 0.01960784, 0.254902)
        /// </summary>
        public static Color EggplantPurple { get; } = new Color(0.2627451f, 0.01960784f, 0.254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4588235, 0.09803922, 0.4509804)
        /// </summary>
        public static Color DarkishPurple { get; } = new Color(0.4588235f, 0.09803922f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9803922, 0.372549, 0.9686275)
        /// </summary>
        public static Color LightMagenta { get; } = new Color(0.9803922f, 0.372549f, 0.9686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2862745, 0.02352941, 0.282353)
        /// </summary>
        public static Color DeepViolet { get; } = new Color(0.2862745f, 0.02352941f, 0.282353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8588235, 0.2941177, 0.854902)
        /// </summary>
        public static Color PinkPurple { get; } = new Color(0.8588235f, 0.2941177f, 0.854902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5803922, 0.4941176, 0.5803922)
        /// </summary>
        public static Color PurpleyGrey { get; } = new Color(0.5803922f, 0.4941176f, 0.5803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9843137, 0.372549, 0.9882353)
        /// </summary>
        public static Color VioletPink { get; } = new Color(0.9843137f, 0.372549f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8392157, 0.282353, 0.8431373)
        /// </summary>
        public static Color PinkishPurple { get; } = new Color(0.8392157f, 0.282353f, 0.8431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3058824, 0.01960784, 0.3137255)
        /// </summary>
        public static Color PlumPurple { get; } = new Color(0.3058824f, 0.01960784f, 0.3137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8431373, 0.145098, 0.8705882)
        /// </summary>
        public static Color Purple_Pink { get; } = new Color(0.8431373f, 0.145098f, 0.8705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6196079, 0.2627451, 0.6352941)
        /// </summary>
        public static Color MediumPurple { get; } = new Color(0.6196079f, 0.2627451f, 0.6352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.1137255, 0.7215686)
        /// </summary>
        public static Color Barney { get; } = new Color(0.6745098f, 0.1137255f, 0.7215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.509804, 0.372549, 0.5294118)
        /// </summary>
        public static Color DustyPurple { get; } = new Color(0.509804f, 0.372549f, 0.5294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9647059, 0.8078431, 0.9882353)
        /// </summary>
        public static Color VeryLightPurple { get; } = new Color(0.9647059f, 0.8078431f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2117647, 0.003921569, 0.2470588)
        /// </summary>
        public static Color DeepPurple { get; } = new Color(0.2117647f, 0.003921569f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5019608, 0.3568628, 0.5294118)
        /// </summary>
        public static Color MutedPurple { get; } = new Color(0.5019608f, 0.3568628f, 0.5294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2078431, 0.02352941, 0.2431373)
        /// </summary>
        public static Color DarkPurple { get; } = new Color(0.2078431f, 0.02352941f, 0.2431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6117647, 0.427451, 0.6470588)
        /// </summary>
        public static Color DarkLilac { get; } = new Color(0.6117647f, 0.427451f, 0.6470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8509804, 0.3098039, 0.9607843)
        /// </summary>
        public static Color Heliotrope { get; } = new Color(0.8509804f, 0.3098039f, 0.9607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0, 0.9607843)
        /// </summary>
        public static Color HotPurple { get; } = new Color(0.7960784f, 0f, 0.9607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2039216, 0.003921569, 0.2470588)
        /// </summary>
        public static Color DarkViolet { get; } = new Color(0.2039216f, 0.003921569f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5686275, 0.4313726, 0.6)
        /// </summary>
        public static Color FadedPurple { get; } = new Color(0.5686275f, 0.4313726f, 0.6f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1647059, 0.003921569, 0.2039216)
        /// </summary>
        public static Color VeryDarkPurple { get; } = new Color(0.1647059f, 0.003921569f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6431373, 0.5176471, 0.6745098)
        /// </summary>
        public static Color Heather { get; } = new Color(0.6431373f, 0.5176471f, 0.6745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6509804, 0.4352941, 0.7098039)
        /// </summary>
        public static Color SoftPurple { get; } = new Color(0.6509804f, 0.4352941f, 0.7098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4784314, 0.4078431, 0.4980392)
        /// </summary>
        public static Color PurplishGrey { get; } = new Color(0.4784314f, 0.4078431f, 0.4980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6784314, 0.01176471, 0.8705882)
        /// </summary>
        public static Color VibrantPurple { get; } = new Color(0.6784314f, 0.01176471f, 0.8705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5960785, 0.2470588, 0.6980392)
        /// </summary>
        public static Color Purply { get; } = new Color(0.5960785f, 0.2470588f, 0.6980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4941176, 0.1176471, 0.6117647)
        /// </summary>
        public static Color Purple { get; } = new Color(0.4941176f, 0.1176471f, 0.6117647f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9372549, 0.7529412, 0.9960784)
        /// </summary>
        public static Color LightLavendar { get; } = new Color(0.9372549f, 0.7529412f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7450981, 0.01176471, 0.9921569)
        /// </summary>
        public static Color BrightPurple { get; } = new Color(0.7450981f, 0.01176471f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1568628, 0.003921569, 0.2156863)
        /// </summary>
        public static Color MidnightPurple { get; } = new Color(0.1568628f, 0.003921569f, 0.2156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7372549, 0.07450981, 0.9960784)
        /// </summary>
        public static Color NeonPurple { get; } = new Color(0.7372549f, 0.07450981f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5333334, 0.4431373, 0.5686275)
        /// </summary>
        public static Color GreyishPurple { get; } = new Color(0.5333334f, 0.4431373f, 0.5686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2941177, 0, 0.4313726)
        /// </summary>
        public static Color RoyalPurple { get; } = new Color(0.2941177f, 0f, 0.4313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7882353, 0.3686275, 0.9843137)
        /// </summary>
        public static Color BrightLilac { get; } = new Color(0.7882353f, 0.3686275f, 0.9843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.509804, 0.427451, 0.5490196)
        /// </summary>
        public static Color GreyPurple { get; } = new Color(0.509804f, 0.427451f, 0.5490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9294118, 0.7843137, 1)
        /// </summary>
        public static Color LightLilac { get; } = new Color(0.9294118f, 0.7843137f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6784314, 0.03921569, 0.9921569)
        /// </summary>
        public static Color BrightViolet { get; } = new Color(0.6784314f, 0.03921569f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9333333, 0.8117647, 0.9960784)
        /// </summary>
        public static Color PaleLavender { get; } = new Color(0.9333333f, 0.8117647f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7803922, 0.3764706, 1)
        /// </summary>
        public static Color BrightLavender { get; } = new Color(0.7803922f, 0.3764706f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6039216, 0.05490196, 0.9176471)
        /// </summary>
        public static Color Violet { get; } = new Color(0.6039216f, 0.05490196f, 0.9176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.4901961, 0.7607843)
        /// </summary>
        public static Color Wisteria { get; } = new Color(0.6588235f, 0.4901961f, 0.7607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6078432, 0.372549, 0.7529412)
        /// </summary>
        public static Color Amethyst { get; } = new Color(0.6078432f, 0.372549f, 0.7529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6666667, 0.1372549, 1)
        /// </summary>
        public static Color ElectricPurple { get; } = new Color(0.6666667f, 0.1372549f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5215687, 0.4039216, 0.5960785)
        /// </summary>
        public static Color DarkLavender { get; } = new Color(0.5215687f, 0.4039216f, 0.5960785f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6, 0, 0.9803922)
        /// </summary>
        public static Color VividPurple { get; } = new Color(0.6f, 0f, 0.9803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7176471, 0.5647059, 0.8313726)
        /// </summary>
        public static Color PalePurple { get; } = new Color(0.7176471f, 0.5647059f, 0.8313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7490196, 0.4666667, 0.9647059)
        /// </summary>
        public static Color LightPurple { get; } = new Color(0.7490196f, 0.4666667f, 0.9647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6470588, 0.3215686, 0.9019608)
        /// </summary>
        public static Color LightishPurple { get; } = new Color(0.6470588f, 0.3215686f, 0.9019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7529412, 0.4431373, 0.9960784)
        /// </summary>
        public static Color EasterPurple { get; } = new Color(0.7529412f, 0.4431373f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5529412, 0.3686275, 0.7176471)
        /// </summary>
        public static Color DeepLavender { get; } = new Color(0.5529412f, 0.3686275f, 0.7176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7921569, 0.6078432, 0.9686275)
        /// </summary>
        public static Color BabyPurple { get; } = new Color(0.7921569f, 0.6078432f, 0.9686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5882353, 0.4313726, 0.7411765)
        /// </summary>
        public static Color DeepLilac { get; } = new Color(0.5882353f, 0.4313726f, 0.7411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7019608, 0.4352941, 0.9647059)
        /// </summary>
        public static Color LightUrple { get; } = new Color(0.7019608f, 0.4352941f, 0.9647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7803922, 0.6235294, 0.9372549)
        /// </summary>
        public static Color Lavender { get; } = new Color(0.7803922f, 0.6235294f, 0.9372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6470588, 0.3529412, 0.9568627)
        /// </summary>
        public static Color LighterPurple { get; } = new Color(0.6470588f, 0.3529412f, 0.9568627f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7686275, 0.5568628, 0.9921569)
        /// </summary>
        public static Color Liliac { get; } = new Color(0.7686275f, 0.5568628f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8078431, 0.6352941, 0.9921569)
        /// </summary>
        public static Color Lilac { get; } = new Color(0.8078431f, 0.6352941f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8941177, 0.7960784, 1)
        /// </summary>
        public static Color PaleLilac { get; } = new Color(0.8941177f, 0.7960784f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8392157, 0.7058824, 0.9882353)
        /// </summary>
        public static Color LightViolet { get; } = new Color(0.8392157f, 0.7058824f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8745098, 0.772549, 0.9960784)
        /// </summary>
        public static Color LightLavender { get; } = new Color(0.8745098f, 0.772549f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7921569, 0.627451, 1)
        /// </summary>
        public static Color PastelPurple { get; } = new Color(0.7921569f, 0.627451f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2196078, 0.007843138, 0.509804)
        /// </summary>
        public static Color Indigo { get; } = new Color(0.2196078f, 0.007843138f, 0.509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8078431, 0.682353, 0.9803922)
        /// </summary>
        public static Color PaleViolet { get; } = new Color(0.8078431f, 0.682353f, 0.9803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3647059, 0.02352941, 0.9137255)
        /// </summary>
        public static Color BlueViolet { get; } = new Color(0.3647059f, 0.02352941f, 0.9137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3176471, 0.03921569, 0.7882353)
        /// </summary>
        public static Color VioletBlue { get; } = new Color(0.3176471f, 0.03921569f, 0.7882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3529412, 0.02352941, 0.9372549)
        /// </summary>
        public static Color Blue_Purple { get; } = new Color(0.3529412f, 0.02352941f, 0.9372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4, 0.1019608, 0.9333333)
        /// </summary>
        public static Color PurplyBlue { get; } = new Color(0.4f, 0.1019608f, 0.9333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5294118, 0.3372549, 0.8941177)
        /// </summary>
        public static Color Purpley { get; } = new Color(0.5294118f, 0.3372549f, 0.8941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3647059, 0.1294118, 0.8156863)
        /// </summary>
        public static Color Purple_Blue { get; } = new Color(0.3647059f, 0.1294118f, 0.8156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4392157, 0.2313726, 0.9058824)
        /// </summary>
        public static Color BluishPurple { get; } = new Color(0.4392157f, 0.2313726f, 0.9058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4078431, 0.1960784, 0.8901961)
        /// </summary>
        public static Color Burple { get; } = new Color(0.4078431f, 0.1960784f, 0.8901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3764706, 0.1176471, 0.9764706)
        /// </summary>
        public static Color PurplishBlue { get; } = new Color(0.3764706f, 0.1176471f, 0.9764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1215686, 0.03529412, 0.3294118)
        /// </summary>
        public static Color DarkIndigo { get; } = new Color(0.1215686f, 0.03529412f, 0.3294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3882353, 0.1764706, 0.9137255)
        /// </summary>
        public static Color PurpleBlue { get; } = new Color(0.3882353f, 0.1764706f, 0.9137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3411765, 0.1607843, 0.8078431)
        /// </summary>
        public static Color BluePurple { get; } = new Color(0.3411765f, 0.1607843f, 0.8078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3843137, 0.254902, 0.7803922)
        /// </summary>
        public static Color BlueyPurple { get; } = new Color(0.3843137f, 0.254902f, 0.7803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.372549, 0.2039216, 0.9058824)
        /// </summary>
        public static Color PurpleyBlue { get; } = new Color(0.372549f, 0.2039216f, 0.9058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.227451, 0.09411765, 0.6941177)
        /// </summary>
        public static Color IndigoBlue { get; } = new Color(0.227451f, 0.09411765f, 0.6941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3333333, 0.2235294, 0.8)
        /// </summary>
        public static Color Blurple { get; } = new Color(0.3333333f, 0.2235294f, 0.8f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3803922, 0.2509804, 0.9372549)
        /// </summary>
        public static Color PurpleishBlue { get; } = new Color(0.3803922f, 0.2509804f, 0.9372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1254902, 0, 0.6941177)
        /// </summary>
        public static Color Ultramarine { get; } = new Color(0.1254902f, 0f, 0.6941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3254902, 0.2352941, 0.7764706)
        /// </summary>
        public static Color BlueWithAHintOfPurple { get; } = new Color(0.3254902f, 0.2352941f, 0.7764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.427451, 0.3529412, 0.8117647)
        /// </summary>
        public static Color LightIndigo { get; } = new Color(0.427451f, 0.3529412f, 0.8117647f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5568628, 0.509804, 0.9960784)
        /// </summary>
        public static Color Periwinkle { get; } = new Color(0.5568628f, 0.509804f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3843137, 0.345098, 0.7686275)
        /// </summary>
        public static Color Iris { get; } = new Color(0.3843137f, 0.345098f, 0.7686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.09411765, 0.01960784, 0.8588235)
        /// </summary>
        public static Color UltramarineBlue { get; } = new Color(0.09411765f, 0.01960784f, 0.8588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4, 0.372549, 0.8196079)
        /// </summary>
        public static Color DarkPeriwinkle { get; } = new Color(0.4f, 0.372549f, 0.8196079f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2745098, 0.254902, 0.5882353)
        /// </summary>
        public static Color Blueberry { get; } = new Color(0.2745098f, 0.254902f, 0.5882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.227451, 0.1803922, 0.9960784)
        /// </summary>
        public static Color LightRoyalBlue { get; } = new Color(0.227451f, 0.1803922f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01176471, 0.003921569, 0.1764706)
        /// </summary>
        public static Color Midnight { get; } = new Color(0.01176471f, 0.003921569f, 0.1764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0, 0.2078431)
        /// </summary>
        public static Color MidnightBlue { get; } = new Color(0.007843138f, 0f, 0.2078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.5490196, 0.9058824)
        /// </summary>
        public static Color Perrywinkle { get; } = new Color(0.5607843f, 0.5490196f, 0.9058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5450981, 0.5333334, 0.972549)
        /// </summary>
        public static Color LavenderBlue { get; } = new Color(0.5450981f, 0.5333334f, 0.972549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04705882, 0.02352941, 0.9686275)
        /// </summary>
        public static Color StrongBlue { get; } = new Color(0.04705882f, 0.02352941f, 0.9686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.007843138, 0.4509804)
        /// </summary>
        public static Color DeepBlue { get; } = new Color(0.01568628f, 0.007843138f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03137255, 0.01568628, 0.9764706)
        /// </summary>
        public static Color PrimaryBlue { get; } = new Color(0.03137255f, 0.01568628f, 0.9764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.01176471, 0.282353)
        /// </summary>
        public static Color NightBlue { get; } = new Color(0.01568628f, 0.01176471f, 0.282353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01960784, 0.01568628, 0.6666667)
        /// </summary>
        public static Color RoyalBlue { get; } = new Color(0.01960784f, 0.01568628f, 0.6666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.9921569, 0.9960784)
        /// </summary>
        public static Color PaleGrey { get; } = new Color(0.9921569f, 0.9921569f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.01176471, 0.8862745)
        /// </summary>
        public static Color PureBlue { get; } = new Color(0.007843138f, 0.01176471f, 0.8862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.003921569, 0.2)
        /// </summary>
        public static Color VeryDarkBlue { get; } = new Color(0f, 0.003921569f, 0.2f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.01176471, 0.3568628)
        /// </summary>
        public static Color DarkBlue { get; } = new Color(0f, 0.01176471f, 0.3568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.02352941, 0.4352941)
        /// </summary>
        public static Color DarkRoyalBlue { get; } = new Color(0.007843138f, 0.02352941f, 0.4352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01176471, 0.02745098, 0.3921569)
        /// </summary>
        public static Color Darkblue { get; } = new Color(0.01176471f, 0.02745098f, 0.3921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01176471, 0.03921569, 0.654902)
        /// </summary>
        public static Color CobaltBlue { get; } = new Color(0.01176471f, 0.03921569f, 0.654902f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.007843138, 0.1803922)
        /// </summary>
        public static Color DarkNavyBlue { get; } = new Color(0f, 0.007843138f, 0.1803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3058824, 0.3176471, 0.5450981)
        /// </summary>
        public static Color Twilight { get; } = new Color(0.3058824f, 0.3176471f, 0.5450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.05882353, 0.8)
        /// </summary>
        public static Color TrueBlue { get; } = new Color(0.003921569f, 0.05882353f, 0.8f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.01568628, 0.2078431)
        /// </summary>
        public static Color DarkNavy { get; } = new Color(0f, 0.01568628f, 0.2078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04705882, 0.09019608, 0.5764706)
        /// </summary>
        public static Color Royal { get; } = new Color(0.04705882f, 0.09019608f, 0.5764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2941177, 0.3411765, 0.8588235)
        /// </summary>
        public static Color WarmBlue { get; } = new Color(0.2941177f, 0.3411765f, 0.8588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7568628, 0.7764706, 0.9882353)
        /// </summary>
        public static Color LightPeriwinkle { get; } = new Color(0.7568628f, 0.7764706f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.6, 0.9843137)
        /// </summary>
        public static Color PeriwinkleBlue { get; } = new Color(0.5607843f, 0.6f, 0.9843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.1058824, 0.9764706)
        /// </summary>
        public static Color RichBlue { get; } = new Color(0.007843138f, 0.1058824f, 0.9764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4156863, 0.4745098, 0.9686275)
        /// </summary>
        public static Color Cornflower { get; } = new Color(0.4156863f, 0.4745098f, 0.9686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.08235294, 0.1803922, 1)
        /// </summary>
        public static Color VividBlue { get; } = new Color(0.08235294f, 0.1803922f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3058824, 0.3294118, 0.5058824)
        /// </summary>
        public static Color Dusk { get; } = new Color(0.3058824f, 0.3294118f, 0.5058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1294118, 0.2196078, 0.6705883)
        /// </summary>
        public static Color Sapphire { get; } = new Color(0.1294118f, 0.2196078f, 0.6705883f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1333333, 0.2588235, 0.7803922)
        /// </summary>
        public static Color BlueBlue { get; } = new Color(0.1333333f, 0.2588235f, 0.7803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01176471, 0.2235294, 0.972549)
        /// </summary>
        public static Color VibrantBlue { get; } = new Color(0.01176471f, 0.2235294f, 0.972549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3176471, 0.4392157, 0.8431373)
        /// </summary>
        public static Color CornflowerBlue { get; } = new Color(0.3176471f, 0.4392157f, 0.8431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.06666667, 0.2745098)
        /// </summary>
        public static Color NavyBlue { get; } = new Color(0f, 0.06666667f, 0.2745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3921569, 0.5333334, 0.9176471)
        /// </summary>
        public static Color SoftBlue { get; } = new Color(0.3921569f, 0.5333334f, 0.9176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01176471, 0.2627451, 0.8745098)
        /// </summary>
        public static Color Blue { get; } = new Color(0.01176471f, 0.2627451f, 0.8745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02352941, 0.3215686, 1)
        /// </summary>
        public static Color ElectricBlue { get; } = new Color(0.02352941f, 0.3215686f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1137255, 0.3647059, 0.9254902)
        /// </summary>
        public static Color Azul { get; } = new Color(0.1137255f, 0.3647059f, 0.9254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2784314, 0.372549, 0.5803922)
        /// </summary>
        public static Color DuskyBlue { get; } = new Color(0.2784314f, 0.372549f, 0.5803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6352941, 0.7490196, 0.9960784)
        /// </summary>
        public static Color PastelBlue { get; } = new Color(0.6352941f, 0.7490196f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2392157, 0.4784314, 0.9921569)
        /// </summary>
        public static Color LightishBlue { get; } = new Color(0.2392157f, 0.4784314f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.08235294, 0.2431373)
        /// </summary>
        public static Color Navy { get; } = new Color(0.003921569f, 0.08235294f, 0.2431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2431373, 0.509804, 0.9882353)
        /// </summary>
        public static Color DodgerBlue { get; } = new Color(0.2431373f, 0.509804f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2313726, 0.3568628, 0.572549)
        /// </summary>
        public static Color DenimBlue { get; } = new Color(0.2313726f, 0.3568628f, 0.572549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1176471, 0.282353, 0.5607843)
        /// </summary>
        public static Color Cobalt { get; } = new Color(0.1176471f, 0.282353f, 0.5607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2627451, 0.4196078, 0.6784314)
        /// </summary>
        public static Color FrenchBlue { get; } = new Color(0.2627451f, 0.4196078f, 0.6784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1411765, 0.4784314, 0.9921569)
        /// </summary>
        public static Color ClearBlue { get; } = new Color(0.1411765f, 0.4784314f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5411765, 0.7215686, 0.9960784)
        /// </summary>
        public static Color CarolinaBlue { get; } = new Color(0.5411765f, 0.7215686f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.3960784, 0.9882353)
        /// </summary>
        public static Color BrightBlue { get; } = new Color(0.003921569f, 0.3960784f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1058824, 0.1411765, 0.1921569)
        /// </summary>
        public static Color Dark { get; } = new Color(0.1058824f, 0.1411765f, 0.1921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7176471, 0.7882353, 0.8862745)
        /// </summary>
        public static Color LightBlueGrey { get; } = new Color(0.7176471f, 0.7882353f, 0.8862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6941177, 0.8196079, 0.9882353)
        /// </summary>
        public static Color PowderBlue { get; } = new Color(0.6941177f, 0.8196079f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1490196, 0.3254902, 0.5529412)
        /// </summary>
        public static Color DuskBlue { get; } = new Color(0.1490196f, 0.3254902f, 0.5529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.05098039, 0.4588235, 0.972549)
        /// </summary>
        public static Color DeepSkyBlue { get; } = new Color(0.05098039f, 0.4588235f, 0.972549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01960784, 0.4313726, 0.9333333)
        /// </summary>
        public static Color CeruleanBlue { get; } = new Color(0.01960784f, 0.4313726f, 0.9333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0.5490196, 0.7333333)
        /// </summary>
        public static Color FadedBlue { get; } = new Color(0.3960784f, 0.5490196f, 0.7333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.1803922, 0.3764706)
        /// </summary>
        public static Color Marine { get; } = new Color(0.01568628f, 0.1803922f, 0.3764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2666667, 0.5568628, 0.8941177)
        /// </summary>
        public static Color DarkSkyBlue { get; } = new Color(0.2666667f, 0.5568628f, 0.8941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.172549, 0.4352941, 0.7333333)
        /// </summary>
        public static Color MediumBlue { get; } = new Color(0.172549f, 0.4352941f, 0.7333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2156863, 0.4705882, 0.7490196)
        /// </summary>
        public static Color WindowsBlue { get; } = new Color(0.2156863f, 0.4705882f, 0.7490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1529412, 0.4156863, 0.7019608)
        /// </summary>
        public static Color MidBlue { get; } = new Color(0.1529412f, 0.4156863f, 0.7019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1803922, 0.3529412, 0.5333334)
        /// </summary>
        public static Color LightNavyBlue { get; } = new Color(0.1803922f, 0.3529412f, 0.5333334f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.7607843, 0.8509804)
        /// </summary>
        public static Color CloudyBlue { get; } = new Color(0.6745098f, 0.7607843f, 0.8509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6352941, 0.8117647, 0.9960784)
        /// </summary>
        public static Color BabyBlue { get; } = new Color(0.6352941f, 0.8117647f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2313726, 0.3882353, 0.5490196)
        /// </summary>
        public static Color Denim { get; } = new Color(0.2313726f, 0.3882353f, 0.5490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.254902, 0.509804)
        /// </summary>
        public static Color DarkishBlue { get; } = new Color(0.003921569f, 0.254902f, 0.509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03921569, 0.2627451, 0.4784314)
        /// </summary>
        public static Color TwilightBlue { get; } = new Color(0.03921569f, 0.2627451f, 0.4784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2352941, 0.4509804, 0.6588235)
        /// </summary>
        public static Color FlatBlue { get; } = new Color(0.2352941f, 0.4509804f, 0.6588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4588235, 0.7333333, 0.9921569)
        /// </summary>
        public static Color SkyBlue { get; } = new Color(0.4588235f, 0.7333333f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4588235, 0.5529412, 0.6392157)
        /// </summary>
        public static Color Blue_Grey { get; } = new Color(0.4588235f, 0.5529412f, 0.6392157f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3372549, 0.5176471, 0.682353)
        /// </summary>
        public static Color OffBlue { get; } = new Color(0.3372549f, 0.5176471f, 0.682353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.2196078, 0.4156863)
        /// </summary>
        public static Color MarineBlue { get; } = new Color(0.003921569f, 0.2196078f, 0.4156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1607843, 0.4627451, 0.7333333)
        /// </summary>
        public static Color Bluish { get; } = new Color(0.1607843f, 0.4627451f, 0.7333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3058824, 0.454902, 0.5882353)
        /// </summary>
        public static Color CadetBlue { get; } = new Color(0.3058824f, 0.454902f, 0.5882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4509804, 0.5215687, 0.5843138)
        /// </summary>
        public static Color Steel { get; } = new Color(0.4509804f, 0.5215687f, 0.5843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2862745, 0.4588235, 0.6117647)
        /// </summary>
        public static Color DullBlue { get; } = new Color(0.2862745f, 0.4588235f, 0.6117647f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3529412, 0.5254902, 0.6784314)
        /// </summary>
        public static Color DustyBlue { get; } = new Color(0.3529412f, 0.5254902f, 0.6784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.08235294, 0.3137255, 0.5176471)
        /// </summary>
        public static Color LightNavy { get; } = new Color(0.08235294f, 0.3137255f, 0.5176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2862745, 0.5176471, 0.7215686)
        /// </summary>
        public static Color CoolBlue { get; } = new Color(0.2862745f, 0.5176471f, 0.7215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3568628, 0.4862745, 0.6)
        /// </summary>
        public static Color SlateBlue { get; } = new Color(0.3568628f, 0.4862745f, 0.6f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2313726, 0.4431373, 0.6235294)
        /// </summary>
        public static Color MutedBlue { get; } = new Color(0.2313726f, 0.4431373f, 0.6235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3529412, 0.4901961, 0.6039216)
        /// </summary>
        public static Color SteelBlue { get; } = new Color(0.3529412f, 0.4901961f, 0.6039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3686275, 0.5058824, 0.6156863)
        /// </summary>
        public static Color GreyishBlue { get; } = new Color(0.3686275f, 0.5058824f, 0.6156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4196078, 0.5450981, 0.6431373)
        /// </summary>
        public static Color GreyBlue { get; } = new Color(0.4196078f, 0.5450981f, 0.6431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 0.7372549, 0.8313726)
        /// </summary>
        public static Color LightGreyBlue { get; } = new Color(0.6156863f, 0.7372549f, 0.8313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3137255, 0.4823529, 0.6117647)
        /// </summary>
        public static Color StormyBlue { get; } = new Color(0.3137255f, 0.4823529f, 0.6117647f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3098039, 0.4509804, 0.5568628)
        /// </summary>
        public static Color MetallicBlue { get; } = new Color(0.3098039f, 0.4509804f, 0.5568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5843138, 0.8156863, 0.9882353)
        /// </summary>
        public static Color LightBlue { get; } = new Color(0.5843138f, 0.8156863f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.2705882, 0.4666667)
        /// </summary>
        public static Color PrussianBlue { get; } = new Color(0f, 0.2705882f, 0.4666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1607843, 0.2745098, 0.3568628)
        /// </summary>
        public static Color DarkGreyBlue { get; } = new Color(0.1607843f, 0.2745098f, 0.3568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5372549, 0.627451, 0.6901961)
        /// </summary>
        public static Color BlueyGrey { get; } = new Color(0.5372549f, 0.627451f, 0.6901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.509804, 0.7921569, 0.9882353)
        /// </summary>
        public static Color Sky { get; } = new Color(0.509804f, 0.7921569f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1294118, 0.2784314, 0.3803922)
        /// </summary>
        public static Color DarkSlateBlue { get; } = new Color(0.1294118f, 0.2784314f, 0.3803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3921569, 0.4901961, 0.5568628)
        /// </summary>
        public static Color Grey_Blue { get; } = new Color(0.3921569f, 0.4901961f, 0.5568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1921569, 0.4, 0.5411765)
        /// </summary>
        public static Color UglyBlue { get; } = new Color(0.1921569f, 0.4f, 0.5411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3490196, 0.3960784, 0.427451)
        /// </summary>
        public static Color SlateGrey { get; } = new Color(0.3490196f, 0.3960784f, 0.427451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3176471, 0.3960784, 0.4470588)
        /// </summary>
        public static Color Slate { get; } = new Color(0.3176471f, 0.3960784f, 0.4470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1215686, 0.2313726, 0.3019608)
        /// </summary>
        public static Color DarkBlueGrey { get; } = new Color(0.1215686f, 0.2313726f, 0.3019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3764706, 0.4862745, 0.5568628)
        /// </summary>
        public static Color BlueGrey { get; } = new Color(0.3764706f, 0.4862745f, 0.5568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02352941, 0.6039216, 0.9529412)
        /// </summary>
        public static Color Azure { get; } = new Color(0.02352941f, 0.6039216f, 0.9529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4823529, 0.7843137, 0.9647059)
        /// </summary>
        public static Color Lightblue { get; } = new Color(0.4823529f, 0.7843137f, 0.9647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.5215687, 0.8196079)
        /// </summary>
        public static Color Cerulean { get; } = new Color(0.01568628f, 0.5215687f, 0.8196079f);

        /// <summary>
        /// A formatted XKCD survey colour (0.05490196, 0.5294118, 0.8)
        /// </summary>
        public static Color WaterBlue { get; } = new Color(0.05490196f, 0.5294118f, 0.8f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.3294118, 0.509804)
        /// </summary>
        public static Color DeepSeaBlue { get; } = new Color(0.003921569f, 0.3294118f, 0.509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4196078, 0.4862745, 0.5215687)
        /// </summary>
        public static Color BattleshipGrey { get; } = new Color(0.4196078f, 0.4862745f, 0.5215687f);

        /// <summary>
        /// A formatted XKCD survey colour (0.454902, 0.5450981, 0.5921569)
        /// </summary>
        public static Color BluishGrey { get; } = new Color(0.454902f, 0.5450981f, 0.5921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.0627451, 0.4784314, 0.6901961)
        /// </summary>
        public static Color NiceBlue { get; } = new Color(0.0627451f, 0.4784314f, 0.6901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5215687, 0.6392157, 0.6980392)
        /// </summary>
        public static Color Bluegrey { get; } = new Color(0.5215687f, 0.6392157f, 0.6980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4666667, 0.6313726, 0.7098039)
        /// </summary>
        public static Color Greyblue { get; } = new Color(0.4666667f, 0.6313726f, 0.7098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.4039216, 0.5843138)
        /// </summary>
        public static Color PeacockBlue { get; } = new Color(0.003921569f, 0.4039216f, 0.5843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4352941, 0.509804, 0.5411765)
        /// </summary>
        public static Color SteelGrey { get; } = new Color(0.4352941f, 0.509804f, 0.5411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2470588, 0.509804, 0.6156863)
        /// </summary>
        public static Color DirtyBlue { get; } = new Color(0.2470588f, 0.509804f, 0.6156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01176471, 0.4431373, 0.6117647)
        /// </summary>
        public static Color OceanBlue { get; } = new Color(0.01176471f, 0.4431373f, 0.6117647f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3254902, 0.3843137, 0.4039216)
        /// </summary>
        public static Color Gunmetal { get; } = new Color(0.3254902f, 0.3843137f, 0.4039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.454902, 0.5843138)
        /// </summary>
        public static Color SeaBlue { get; } = new Color(0.01568628f, 0.454902f, 0.5843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.8, 0.9960784)
        /// </summary>
        public static Color BrightSkyBlue { get; } = new Color(0.007843138f, 0.8f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5843138, 0.6392157, 0.6509804)
        /// </summary>
        public static Color CoolGrey { get; } = new Color(0.5843138f, 0.6392157f, 0.6509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2352941, 0.254902, 0.2588235)
        /// </summary>
        public static Color CharcoalGrey { get; } = new Color(0.2352941f, 0.254902f, 0.2588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.4823529, 0.572549)
        /// </summary>
        public static Color Ocean { get; } = new Color(0.003921569f, 0.4823529f, 0.572549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.8509804, 1)
        /// </summary>
        public static Color NeonBlue { get; } = new Color(0.01568628f, 0.8509804f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.5333334, 0.6235294)
        /// </summary>
        public static Color TealBlue { get; } = new Color(0.003921569f, 0.5333334f, 0.6235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7411765, 0.9647059, 0.9960784)
        /// </summary>
        public static Color PaleSkyBlue { get; } = new Color(0.7411765f, 0.9647059f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5411765, 0.945098, 0.9960784)
        /// </summary>
        public static Color RobinEggBlue { get; } = new Color(0.5411765f, 0.945098f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.427451, 0.9294118, 0.9921569)
        /// </summary>
        public static Color RobinSEgg { get; } = new Color(0.427451f, 0.9294118f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.372549, 0.4156863)
        /// </summary>
        public static Color Petrol { get; } = new Color(0f, 0.372549f, 0.4156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5960785, 0.9372549, 0.9764706)
        /// </summary>
        public static Color RobinSEggBlue { get; } = new Color(0.5960785f, 0.9372549f, 0.9764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02352941, 0.6941177, 0.7686275)
        /// </summary>
        public static Color TurquoiseBlue { get; } = new Color(0.02352941f, 0.6941177f, 0.7686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.8470588, 0.9137255)
        /// </summary>
        public static Color AquaBlue { get; } = new Color(0.007843138f, 0.8470588f, 0.9137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03137255, 0.4705882, 0.4980392)
        /// </summary>
        public static Color DeepAqua { get; } = new Color(0.03137255f, 0.4705882f, 0.4980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.3333333, 0.3529412)
        /// </summary>
        public static Color DeepTeal { get; } = new Color(0f, 0.3333333f, 0.3529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7764706, 0.9882353, 1)
        /// </summary>
        public static Color LightSkyBlue { get; } = new Color(0.7764706f, 0.9882353f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1490196, 0.9686275, 0.9921569)
        /// </summary>
        public static Color BrightLightBlue { get; } = new Color(0.1490196f, 0.9686275f, 0.9921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01960784, 0.4117647, 0.4196078)
        /// </summary>
        public static Color DarkAqua { get; } = new Color(0.01960784f, 0.4117647f, 0.4196078f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03921569, 0.5333334, 0.5411765)
        /// </summary>
        public static Color DarkCyan { get; } = new Color(0.03921569f, 0.5333334f, 0.5411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.3019608, 0.3058824)
        /// </summary>
        public static Color DarkTeal { get; } = new Color(0.003921569f, 0.3019608f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.4509804, 0.454902)
        /// </summary>
        public static Color DeepTurquoise { get; } = new Color(0.003921569f, 0.4509804f, 0.454902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.254902, 0.9921569, 0.9960784)
        /// </summary>
        public static Color BrightCyan { get; } = new Color(0.254902f, 0.9921569f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 1, 1)
        /// </summary>
        public static Color Cyan { get; } = new Color(0f, 1f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02745098, 0.05098039, 0.05098039)
        /// </summary>
        public static Color AlmostBlack { get; } = new Color(0.02745098f, 0.05098039f, 0.05098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8156863, 0.9960784, 0.9960784)
        /// </summary>
        public static Color PaleBlue { get; } = new Color(0.8156863f, 0.9960784f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8313726, 1, 1)
        /// </summary>
        public static Color ReallyLightBlue { get; } = new Color(0.8313726f, 1f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8352941, 1, 1)
        /// </summary>
        public static Color VeryLightBlue { get; } = new Color(0.8352941f, 1f, 1f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2117647, 0.2156863, 0.2156863)
        /// </summary>
        public static Color DarkGrey { get; } = new Color(0.2117647f, 0.2156863f, 0.2156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.4784314, 0.4745098)
        /// </summary>
        public static Color Bluegreen { get; } = new Color(0.003921569f, 0.4784314f, 0.4745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.4509804, 0.4431373)
        /// </summary>
        public static Color DarkAquamarine { get; } = new Color(0.003921569f, 0.4509804f, 0.4431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.05882353, 0.9960784, 0.9764706)
        /// </summary>
        public static Color BrightTurquoise { get; } = new Color(0.05882353f, 0.9960784f, 0.9764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.3607843, 0.3529412)
        /// </summary>
        public static Color DarkTurquoise { get; } = new Color(0.01568628f, 0.3607843f, 0.3529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8392157, 1, 0.9960784)
        /// </summary>
        public static Color VeryPaleBlue { get; } = new Color(0.8392157f, 1f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8431373, 1, 0.9960784)
        /// </summary>
        public static Color IceBlue { get; } = new Color(0.8431373f, 1f, 0.9960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04313726, 0.5450981, 0.5294118)
        /// </summary>
        public static Color GreenishBlue { get; } = new Color(0.04313726f, 0.5450981f, 0.5294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 1, 0.9882353)
        /// </summary>
        public static Color LightCyan { get; } = new Color(0.6745098f, 1f, 0.9882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04313726, 0.9764706, 0.9176471)
        /// </summary>
        public static Color BrightAqua { get; } = new Color(0.04313726f, 0.9764706f, 0.9176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7176471, 1, 0.9803922)
        /// </summary>
        public static Color PaleCyan { get; } = new Color(0.7176471f, 1f, 0.9803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.07450981, 0.7333333, 0.6862745)
        /// </summary>
        public static Color Topaz { get; } = new Color(0.07450981f, 0.7333333f, 0.6862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2352941, 0.6, 0.572549)
        /// </summary>
        public static Color Sea { get; } = new Color(0.2352941f, 0.6f, 0.572549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7921569, 1, 0.9843137)
        /// </summary>
        public static Color LightLightBlue { get; } = new Color(0.7921569f, 1f, 0.9843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.5764706, 0.5254902)
        /// </summary>
        public static Color Teal { get; } = new Color(0.007843138f, 0.5764706f, 0.5254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.05882353, 0.6078432, 0.5568628)
        /// </summary>
        public static Color Blue_Green { get; } = new Color(0.05882353f, 0.6078432f, 0.5568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.3215686, 0.2862745)
        /// </summary>
        public static Color DarkBlueGreen { get; } = new Color(0f, 0.3215686f, 0.2862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02352941, 0.7607843, 0.6745098)
        /// </summary>
        public static Color Turquoise { get; } = new Color(0.02352941f, 0.7607843f, 0.6745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8392157, 1, 0.9803922)
        /// </summary>
        public static Color Ice { get; } = new Color(0.8392157f, 1f, 0.9803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7647059, 0.9843137, 0.9568627)
        /// </summary>
        public static Color DuckEggBlue { get; } = new Color(0.7647059f, 0.9843137f, 0.9568627f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1411765, 0.7372549, 0.6588235)
        /// </summary>
        public static Color Tealish { get; } = new Color(0.1411765f, 0.7372549f, 0.6588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7686275, 1, 0.9686275)
        /// </summary>
        public static Color EggshellBlue { get; } = new Color(0.7686275f, 1f, 0.9686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.07450981, 0.9176471, 0.7882353)
        /// </summary>
        public static Color Aqua { get; } = new Color(0.07450981f, 0.9176471f, 0.7882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.07450981, 0.4941176, 0.427451)
        /// </summary>
        public static Color BlueGreen { get; } = new Color(0.07450981f, 0.4941176f, 0.427451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2980392, 0.5647059, 0.5215687)
        /// </summary>
        public static Color DustyTeal { get; } = new Color(0.2980392f, 0.5647059f, 0.5215687f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1215686, 0.3882353, 0.3411765)
        /// </summary>
        public static Color DarkGreenBlue { get; } = new Color(0.1215686f, 0.3882353f, 0.3411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.8470588, 0.6980392)
        /// </summary>
        public static Color Aquamarine { get; } = new Color(0.01568628f, 0.8470588f, 0.6980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4823529, 0.9490196, 0.854902)
        /// </summary>
        public static Color TiffanyBlue { get; } = new Color(0.4823529f, 0.9490196f, 0.854902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.9764706, 0.7764706)
        /// </summary>
        public static Color BrightTeal { get; } = new Color(0.003921569f, 0.9764706f, 0.7764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02352941, 0.7058824, 0.5450981)
        /// </summary>
        public static Color GreenBlue { get; } = new Color(0.02352941f, 0.7058824f, 0.5450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.372549, 0.6196079, 0.5607843)
        /// </summary>
        public static Color DullTeal { get; } = new Color(0.372549f, 0.6196079f, 0.5607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1803922, 0.9098039, 0.7333333)
        /// </summary>
        public static Color AquaMarine { get; } = new Color(0.1803922f, 0.9098039f, 0.7333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2039216, 0.2196078, 0.2156863)
        /// </summary>
        public static Color Charcoal { get; } = new Color(0.2039216f, 0.2196078f, 0.2156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2588235, 0.7019608, 0.5843138)
        /// </summary>
        public static Color GreenyBlue { get; } = new Color(0.2588235f, 0.7019608f, 0.5843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.7529412, 0.5529412)
        /// </summary>
        public static Color Green_Blue { get; } = new Color(0.003921569f, 0.7529412f, 0.5529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3686275, 0.6078432, 0.5411765)
        /// </summary>
        public static Color GreyTeal { get; } = new Color(0.3686275f, 0.6078432f, 0.5411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7215686, 1, 0.9215686)
        /// </summary>
        public static Color PaleAqua { get; } = new Color(0.7215686f, 1f, 0.9215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.9843137, 0.6901961)
        /// </summary>
        public static Color GreenishTurquoise { get; } = new Color(0f, 0.9843137f, 0.6901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4705882, 0.8196079, 0.7137255)
        /// </summary>
        public static Color SeafoamBlue { get; } = new Color(0.4705882f, 0.8196079f, 0.7137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4431373, 0.6235294, 0.5686275)
        /// </summary>
        public static Color GreyishTeal { get; } = new Color(0.4431373f, 0.6235294f, 0.5686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5490196, 1, 0.8588235)
        /// </summary>
        public static Color LightAqua { get; } = new Color(0.5490196f, 1f, 0.8588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.0627451, 0.6509804, 0.454902)
        /// </summary>
        public static Color BluishGreen { get; } = new Color(0.0627451f, 0.6509804f, 0.454902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1647059, 0.9960784, 0.7176471)
        /// </summary>
        public static Color GreenishCyan { get; } = new Color(0.1647059f, 0.9960784f, 0.7176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4941176, 0.9568627, 0.8)
        /// </summary>
        public static Color LightTurquoise { get; } = new Color(0.4941176f, 0.9568627f, 0.8f);

        /// <summary>
        /// A formatted XKCD survey colour (0.509804, 0.7960784, 0.6980392)
        /// </summary>
        public static Color PaleTeal { get; } = new Color(0.509804f, 0.7960784f, 0.6980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1372549, 0.7686275, 0.5450981)
        /// </summary>
        public static Color Greenblue { get; } = new Color(0.1372549f, 0.7686275f, 0.5450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.06666667, 0.5294118, 0.3647059)
        /// </summary>
        public static Color DarkSeaGreen { get; } = new Color(0.06666667f, 0.5294118f, 0.3647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01960784, 1, 0.6509804)
        /// </summary>
        public static Color BrightSeaGreen { get; } = new Color(0.01960784f, 1f, 0.6509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1176471, 0.5686275, 0.4039216)
        /// </summary>
        public static Color Viridian { get; } = new Color(0.1176471f, 0.5686275f, 0.4039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04705882, 0.7098039, 0.4666667)
        /// </summary>
        public static Color GreenTeal { get; } = new Color(0.04705882f, 0.7098039f, 0.4666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1215686, 0.654902, 0.454902)
        /// </summary>
        public static Color Jade { get; } = new Color(0.1215686f, 0.654902f, 0.454902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.07058824, 0.8823529, 0.5764706)
        /// </summary>
        public static Color AquaGreen { get; } = new Color(0.07058824f, 0.8823529f, 0.5764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1215686, 0.7098039, 0.4784314)
        /// </summary>
        public static Color DarkSeafoam { get; } = new Color(0.1215686f, 0.7098039f, 0.4784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.145098, 0.6392157, 0.4352941)
        /// </summary>
        public static Color TealGreen { get; } = new Color(0.145098f, 0.6392157f, 0.4352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2392157, 0.6, 0.4509804)
        /// </summary>
        public static Color OceanGreen { get; } = new Color(0.2392157f, 0.6f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4823529, 0.9921569, 0.7803922)
        /// </summary>
        public static Color LightAquamarine { get; } = new Color(0.4823529f, 0.9921569f, 0.7803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5647059, 0.8941177, 0.7568628)
        /// </summary>
        public static Color LightTeal { get; } = new Color(0.5647059f, 0.8941177f, 0.7568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1686275, 0.6941177, 0.4745098)
        /// </summary>
        public static Color BlueyGreen { get; } = new Color(0.1686275f, 0.6941177f, 0.4745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1960784, 0.7490196, 0.5176471)
        /// </summary>
        public static Color GreenishTeal { get; } = new Color(0.1960784f, 0.7490196f, 0.5176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01960784, 0.2784314, 0.1647059)
        /// </summary>
        public static Color Evergreen { get; } = new Color(0.01960784f, 0.2784314f, 0.1647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6470588, 0.9843137, 0.8352941)
        /// </summary>
        public static Color PaleTurquoise { get; } = new Color(0.6470588f, 0.9843137f, 0.8352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.9568627, 0.5372549)
        /// </summary>
        public static Color TurquoiseGreen { get; } = new Color(0.01568628f, 0.9568627f, 0.5372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3882353, 0.9686275, 0.7058824)
        /// </summary>
        public static Color LightGreenishBlue { get; } = new Color(0.3882353f, 0.9686275f, 0.7058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03921569, 0.372549, 0.2196078)
        /// </summary>
        public static Color Spruce { get; } = new Color(0.03921569f, 0.372549f, 0.2196078f);

        /// <summary>
        /// A formatted XKCD survey colour (0.09411765, 0.8196079, 0.4823529)
        /// </summary>
        public static Color Seaweed { get; } = new Color(0.09411765f, 0.8196079f, 0.4823529f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1254902, 0.7529412, 0.4509804)
        /// </summary>
        public static Color DarkMintGreen { get; } = new Color(0.1254902f, 0.7529412f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.509804, 0.2627451)
        /// </summary>
        public static Color JungleGreen { get; } = new Color(0.01568628f, 0.509804f, 0.2627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.772549, 0.7882353, 0.7803922)
        /// </summary>
        public static Color Silver { get; } = new Color(0.772549f, 0.7882353f, 0.7803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2431373, 0.6862745, 0.4627451)
        /// </summary>
        public static Color DarkSeafoamGreen { get; } = new Color(0.2431373f, 0.6862745f, 0.4627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04705882, 0.8627451, 0.4509804)
        /// </summary>
        public static Color TealishGreen { get; } = new Color(0.04705882f, 0.8627451f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04313726, 0.9686275, 0.4901961)
        /// </summary>
        public static Color MintyGreen { get; } = new Color(0.04313726f, 0.9686275f, 0.4901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1294118, 0.7647059, 0.4352941)
        /// </summary>
        public static Color AlgaeGreen { get; } = new Color(0.1294118f, 0.7647059f, 0.4352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1686275, 0.6862745, 0.4156863)
        /// </summary>
        public static Color JadeGreen { get; } = new Color(0.1686275f, 0.6862745f, 0.4156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1254902, 0.9764706, 0.5254902)
        /// </summary>
        public static Color Wintergreen { get; } = new Color(0.1254902f, 0.9764706f, 0.5254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3254902, 0.9882353, 0.6313726)
        /// </summary>
        public static Color SeaGreen { get; } = new Color(0.3254902f, 0.9882353f, 0.6313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3372549, 0.9882353, 0.6352941)
        /// </summary>
        public static Color LightGreenBlue { get; } = new Color(0.3372549f, 0.9882353f, 0.6352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.627451, 0.2862745)
        /// </summary>
        public static Color Emerald { get; } = new Color(0.003921569f, 0.627451f, 0.2862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2078431, 0.6784314, 0.4196078)
        /// </summary>
        public static Color SeaweedGreen { get; } = new Color(0.2078431f, 0.6784314f, 0.4196078f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4941176, 0.9843137, 0.7019608)
        /// </summary>
        public static Color LightBlueGreen { get; } = new Color(0.4941176f, 0.9843137f, 0.7019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.7058824, 0.2980392)
        /// </summary>
        public static Color Shamrock { get; } = new Color(0.003921569f, 0.7058824f, 0.2980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2509804, 0.6392157, 0.4078431)
        /// </summary>
        public static Color Greenish { get; } = new Color(0.2509804f, 0.6392157f, 0.4078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1176471, 0.972549, 0.4627451)
        /// </summary>
        public static Color Spearmint { get; } = new Color(0.1176471f, 0.972549f, 0.4627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.227451, 0.8980392, 0.4980392)
        /// </summary>
        public static Color WeirdGreen { get; } = new Color(0.227451f, 0.8980392f, 0.4980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.7568628, 0.3019608)
        /// </summary>
        public static Color ShamrockGreen { get; } = new Color(0.007843138f, 0.7568628f, 0.3019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4784314, 0.9764706, 0.6705883)
        /// </summary>
        public static Color SeafoamGreen { get; } = new Color(0.4784314f, 0.9764706f, 0.6705883f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.5764706, 0.2156863)
        /// </summary>
        public static Color KelleyGreen { get; } = new Color(0f, 0.5764706f, 0.2156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5019608, 0.9764706, 0.6784314)
        /// </summary>
        public static Color Seafoam { get; } = new Color(0.5019608f, 0.9764706f, 0.6784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4627451, 0.9921569, 0.6588235)
        /// </summary>
        public static Color LightBluishGreen { get; } = new Color(0.4627451f, 0.9921569f, 0.6588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2, 0.7215686, 0.3921569)
        /// </summary>
        public static Color CoolGreen { get; } = new Color(0.2f, 0.7215686f, 0.3921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.282353, 0.7529412, 0.4470588)
        /// </summary>
        public static Color DarkMint { get; } = new Color(0.282353f, 0.7529412f, 0.4470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.627451, 0.9960784, 0.7490196)
        /// </summary>
        public static Color LightSeafoam { get; } = new Color(0.627451f, 0.9960784f, 0.7490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0.6705883, 0.4862745)
        /// </summary>
        public static Color Tea { get; } = new Color(0.3960784f, 0.6705883f, 0.4862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03921569, 0.282353, 0.1176471)
        /// </summary>
        public static Color PineGreen { get; } = new Color(0.03921569f, 0.282353f, 0.1176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.5843138, 0.1607843)
        /// </summary>
        public static Color IrishGreen { get; } = new Color(0.003921569f, 0.5843138f, 0.1607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.6705883, 0.1803922)
        /// </summary>
        public static Color KellyGreen { get; } = new Color(0.007843138f, 0.6705883f, 0.1803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5960785, 0.9647059, 0.6901961)
        /// </summary>
        public static Color LightSeaGreen { get; } = new Color(0.5960785f, 0.9647059f, 0.6901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5647059, 0.9921569, 0.6627451)
        /// </summary>
        public static Color FoamGreen { get; } = new Color(0.5647059f, 0.9921569f, 0.6627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3294118, 0.6745098, 0.4078431)
        /// </summary>
        public static Color Algae { get; } = new Color(0.3294118f, 0.6745098f, 0.4078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6078432, 0.8980392, 0.6666667)
        /// </summary>
        public static Color HospitalGreen { get; } = new Color(0.6078432f, 0.8980392f, 0.6666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0.5529412, 0.427451)
        /// </summary>
        public static Color SlateGreen { get; } = new Color(0.3960784f, 0.5529412f, 0.427451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.5607843, 0.1176471)
        /// </summary>
        public static Color EmeraldGreen { get; } = new Color(0.007843138f, 0.5607843f, 0.1176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1764706, 0.9960784, 0.3294118)
        /// </summary>
        public static Color BrightLightGreen { get; } = new Color(0.1764706f, 0.9960784f, 0.3294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1686275, 0.3647059, 0.2039216)
        /// </summary>
        public static Color Pine { get; } = new Color(0.1686275f, 0.3647059f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6235294, 0.9960784, 0.6901961)
        /// </summary>
        public static Color Mint { get; } = new Color(0.6235294f, 0.9960784f, 0.6901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1568628, 0.4862745, 0.2156863)
        /// </summary>
        public static Color DarkishGreen { get; } = new Color(0.1568628f, 0.4862745f, 0.2156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.654902, 1, 0.7098039)
        /// </summary>
        public static Color LightSeafoamGreen { get; } = new Color(0.654902f, 1f, 0.7098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5490196, 1, 0.6196079)
        /// </summary>
        public static Color BabyGreen { get; } = new Color(0.5490196f, 1f, 0.6196079f);

        /// <summary>
        /// A formatted XKCD survey colour (0.007843138, 0.3490196, 0.05882353)
        /// </summary>
        public static Color DeepGreen { get; } = new Color(0.007843138f, 0.3490196f, 0.05882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 1, 0.6235294)
        /// </summary>
        public static Color MintGreen { get; } = new Color(0.5607843f, 1f, 0.6235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6509804, 0.9843137, 0.6980392)
        /// </summary>
        public static Color LightMintGreen { get; } = new Color(0.6509804f, 0.9843137f, 0.6980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2235294, 0.6784314, 0.282353)
        /// </summary>
        public static Color MediumGreen { get; } = new Color(0.2235294f, 0.6784314f, 0.282353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01960784, 0.282353, 0.05098039)
        /// </summary>
        public static Color BritishRacingGreen { get; } = new Color(0.01960784f, 0.282353f, 0.05098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02352941, 0.2784314, 0.04705882)
        /// </summary>
        public static Color ForestGreen { get; } = new Color(0.02352941f, 0.2784314f, 0.04705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0.1764706, 0.01568628)
        /// </summary>
        public static Color DarkForestGreen { get; } = new Color(0f, 0.1764706f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4352941, 0.7607843, 0.4627451)
        /// </summary>
        public static Color SoftGreen { get; } = new Color(0.4352941f, 0.7607843f, 0.4627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7137255, 1, 0.7333333)
        /// </summary>
        public static Color LightMint { get; } = new Color(0.7137255f, 1f, 0.7333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3098039, 0.5686275, 0.3254902)
        /// </summary>
        public static Color LightForestGreen { get; } = new Color(0.3098039f, 0.5686275f, 0.3254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3254902, 0.9960784, 0.3607843)
        /// </summary>
        public static Color LightBrightGreen { get; } = new Color(0.3254902f, 0.9960784f, 0.3607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4627451, 1, 0.4823529)
        /// </summary>
        public static Color Lightgreen { get; } = new Color(0.4627451f, 1f, 0.4823529f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3058824, 0.9921569, 0.3294118)
        /// </summary>
        public static Color LightNeonGreen { get; } = new Color(0.3058824f, 0.9921569f, 0.3294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.08235294, 0.6901961, 0.1019608)
        /// </summary>
        public static Color Green { get; } = new Color(0.08235294f, 0.6901961f, 0.1019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01960784, 0.2862745, 0.02745098)
        /// </summary>
        public static Color Darkgreen { get; } = new Color(0.01960784f, 0.2862745f, 0.02745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3882353, 0.7019608, 0.3960784)
        /// </summary>
        public static Color BoringGreen { get; } = new Color(0.3882353f, 0.7019608f, 0.3960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 1, 0.02745098)
        /// </summary>
        public static Color BrightGreen { get; } = new Color(0.003921569f, 1f, 0.02745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.145098, 1, 0.1607843)
        /// </summary>
        public static Color HotGreen { get; } = new Color(0.145098f, 1f, 0.1607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01568628, 0.2901961, 0.01960784)
        /// </summary>
        public static Color BottleGreen { get; } = new Color(0.01568628f, 0.2901961f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3372549, 0.682353, 0.3411765)
        /// </summary>
        public static Color DarkPastelGreen { get; } = new Color(0.3372549f, 0.682353f, 0.3411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03137255, 1, 0.03137255)
        /// </summary>
        public static Color FluorescentGreen { get; } = new Color(0.03137255f, 1f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04705882, 1, 0.04705882)
        /// </summary>
        public static Color NeonGreen { get; } = new Color(0.04705882f, 1f, 0.04705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3803922, 0.8823529, 0.3764706)
        /// </summary>
        public static Color LightishGreen { get; } = new Color(0.3803922f, 0.8823529f, 0.3764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03921569, 0.8666667, 0.03137255)
        /// </summary>
        public static Color VibrantGreen { get; } = new Color(0.03921569f, 0.8666667f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.003921569, 0.2745098, 0)
        /// </summary>
        public static Color RacingGreen { get; } = new Color(0.003921569f, 0.2745098f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04313726, 0.3333333, 0.03529412)
        /// </summary>
        public static Color Forest { get; } = new Color(0.04313726f, 0.3333333f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03137255, 0.5803922, 0.01568628)
        /// </summary>
        public static Color TrueGreen { get; } = new Color(0.03137255f, 0.5803922f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.03921569, 1, 0.007843138)
        /// </summary>
        public static Color FluroGreen { get; } = new Color(0.03921569f, 1f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.04313726, 0.2509804, 0.03137255)
        /// </summary>
        public static Color HunterGreen { get; } = new Color(0.04313726f, 0.2509804f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4627451, 0.6627451, 0.4509804)
        /// </summary>
        public static Color DustyGreen { get; } = new Color(0.4627451f, 0.6627451f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.01176471, 0.2078431, 0)
        /// </summary>
        public static Color DarkGreen { get; } = new Color(0.01176471f, 0.2078431f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.172549, 0.9803922, 0.1215686)
        /// </summary>
        public static Color RadioactiveGreen { get; } = new Color(0.172549f, 0.9803922f, 0.1215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3490196, 0.5215687, 0.3372549)
        /// </summary>
        public static Color DarkSage { get; } = new Color(0.3490196f, 0.5215687f, 0.3372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.02352941, 0.1803922, 0.01176471)
        /// </summary>
        public static Color VeryDarkGreen { get; } = new Color(0.02352941f, 0.1803922f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1294118, 0.9882353, 0.05098039)
        /// </summary>
        public static Color ElectricGreen { get; } = new Color(0.1294118f, 0.9882353f, 0.05098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1058824, 0.9882353, 0.02352941)
        /// </summary>
        public static Color HighlighterGreen { get; } = new Color(0.1058824f, 0.9882353f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3137255, 0.654902, 0.2784314)
        /// </summary>
        public static Color MidGreen { get; } = new Color(0.3137255f, 0.654902f, 0.2784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7450981, 0.9921569, 0.7176471)
        /// </summary>
        public static Color Celadon { get; } = new Color(0.7450981f, 0.9921569f, 0.7176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4941176, 0.627451, 0.4784314)
        /// </summary>
        public static Color GreenyGrey { get; } = new Color(0.4941176f, 0.627451f, 0.4784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5490196, 0.9921569, 0.4941176)
        /// </summary>
        public static Color EasterGreen { get; } = new Color(0.5490196f, 0.9921569f, 0.4941176f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4823529, 0.6980392, 0.454902)
        /// </summary>
        public static Color FadedGreen { get; } = new Color(0.4823529f, 0.6980392f, 0.454902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4588235, 0.9921569, 0.3882353)
        /// </summary>
        public static Color LighterGreen { get; } = new Color(0.4588235f, 0.9921569f, 0.3882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.509804, 0.6509804, 0.4901961)
        /// </summary>
        public static Color GreyishGreen { get; } = new Color(0.509804f, 0.6509804f, 0.4901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4705882, 0.6078432, 0.4509804)
        /// </summary>
        public static Color GreyGreen { get; } = new Color(0.4705882f, 0.6078432f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1843137, 0.9372549, 0.0627451)
        /// </summary>
        public static Color VividGreen { get; } = new Color(0.1843137f, 0.9372549f, 0.0627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6980392, 0.9843137, 0.6470588)
        /// </summary>
        public static Color LightPastelGreen { get; } = new Color(0.6980392f, 0.9843137f, 0.6470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.372549, 0.627451, 0.3215686)
        /// </summary>
        public static Color MutedGreen { get; } = new Color(0.372549f, 0.627451f, 0.3215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1647059, 0.4941176, 0.09803922)
        /// </summary>
        public static Color TreeGreen { get; } = new Color(0.1647059f, 0.4941176f, 0.09803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3176471, 0.7176471, 0.2313726)
        /// </summary>
        public static Color LeafyGreen { get; } = new Color(0.3176471f, 0.7176471f, 0.2313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2509804, 0.9921569, 0.07843138)
        /// </summary>
        public static Color PoisonGreen { get; } = new Color(0.2509804f, 0.9921569f, 0.07843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4117647, 0.8470588, 0.3098039)
        /// </summary>
        public static Color FreshGreen { get; } = new Color(0.4117647f, 0.8470588f, 0.3098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6901961, 1, 0.6156863)
        /// </summary>
        public static Color PastelGreen { get; } = new Color(0.6901961f, 1f, 0.6156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3882353, 0.6627451, 0.3137255)
        /// </summary>
        public static Color Fern { get; } = new Color(0.3882353f, 0.6627451f, 0.3137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5882353, 0.9764706, 0.4823529)
        /// </summary>
        public static Color LightGreen { get; } = new Color(0.5882353f, 0.9764706f, 0.4823529f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3294118, 0.5529412, 0.2666667)
        /// </summary>
        public static Color FernGreen { get; } = new Color(0.3294118f, 0.5529412f, 0.2666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4666667, 0.572549, 0.4352941)
        /// </summary>
        public static Color GreenGrey { get; } = new Color(0.4666667f, 0.572549f, 0.4352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.08235294, 0.2666667, 0.02352941)
        /// </summary>
        public static Color ForrestGreen { get; } = new Color(0.08235294f, 0.2666667f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6941177, 0.9882353, 0.6)
        /// </summary>
        public static Color PaleLightGreen { get; } = new Color(0.6941177f, 0.9882353f, 0.6f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7803922, 0.9921569, 0.7098039)
        /// </summary>
        public static Color PaleGreen { get; } = new Color(0.7803922f, 0.9921569f, 0.7098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7372549, 0.9254902, 0.6745098)
        /// </summary>
        public static Color LightSage { get; } = new Color(0.7372549f, 0.9254902f, 0.6745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.572549, 0.5843138, 0.5686275)
        /// </summary>
        public static Color Grey { get; } = new Color(0.572549f, 0.5843138f, 0.5686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5254902, 0.6313726, 0.4901961)
        /// </summary>
        public static Color Grey_Green { get; } = new Color(0.5254902f, 0.6313726f, 0.4901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.454902, 0.6509804, 0.3843137)
        /// </summary>
        public static Color DullGreen { get; } = new Color(0.454902f, 0.6509804f, 0.3843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5333334, 0.7019608, 0.4705882)
        /// </summary>
        public static Color SageGreen { get; } = new Color(0.5333334f, 0.7019608f, 0.4705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5882353, 0.682353, 0.5529412)
        /// </summary>
        public static Color GreenishGrey { get; } = new Color(0.5882353f, 0.682353f, 0.5529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7372549, 0.9607843, 0.6509804)
        /// </summary>
        public static Color WashedOutGreen { get; } = new Color(0.7372549f, 0.9607843f, 0.6509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8117647, 0.9921569, 0.7372549)
        /// </summary>
        public static Color VeryPaleGreen { get; } = new Color(0.8117647f, 0.9921569f, 0.7372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4196078, 0.6392157, 0.3254902)
        /// </summary>
        public static Color OffGreen { get; } = new Color(0.4196078f, 0.6392157f, 0.3254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8196079, 1, 0.7411765)
        /// </summary>
        public static Color VeryLightGreen { get; } = new Color(0.8196079f, 1f, 0.7411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 1, 0.6901961)
        /// </summary>
        public static Color LightLightGreen { get; } = new Color(0.7843137f, 1f, 0.6901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3803922, 0.8705882, 0.1647059)
        /// </summary>
        public static Color ToxicGreen { get; } = new Color(0.3803922f, 0.8705882f, 0.1647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7411765, 0.972549, 0.6392157)
        /// </summary>
        public static Color TeaGreen { get; } = new Color(0.7411765f, 0.972549f, 0.6392157f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3686275, 0.8627451, 0.1215686)
        /// </summary>
        public static Color GreenApple { get; } = new Color(0.3686275f, 0.8627451f, 0.1215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8470588, 0.8627451, 0.8392157)
        /// </summary>
        public static Color LightGrey { get; } = new Color(0.8470588f, 0.8627451f, 0.8392157f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4901961, 0.4980392, 0.4862745)
        /// </summary>
        public static Color MediumGrey { get; } = new Color(0.4901961f, 0.4980392f, 0.4862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5294118, 0.682353, 0.4509804)
        /// </summary>
        public static Color Sage { get; } = new Color(0.5294118f, 0.682353f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.7137255, 0.4823529)
        /// </summary>
        public static Color Lichen { get; } = new Color(0.5607843f, 0.7137255f, 0.4823529f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7176471, 0.8823529, 0.6313726)
        /// </summary>
        public static Color LightGreyGreen { get; } = new Color(0.7176471f, 0.8823529f, 0.6313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4313726, 0.7960784, 0.2352941)
        /// </summary>
        public static Color Apple { get; } = new Color(0.4313726f, 0.7960784f, 0.2352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4117647, 0.6156863, 0.2980392)
        /// </summary>
        public static Color FlatGreen { get; } = new Color(0.4117647f, 0.6156863f, 0.2980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2470588, 0.6078432, 0.04313726)
        /// </summary>
        public static Color GrassGreen { get; } = new Color(0.2470588f, 0.6078432f, 0.04313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4588235, 0.7215686, 0.3098039)
        /// </summary>
        public static Color TurtleGreen { get; } = new Color(0.4588235f, 0.7215686f, 0.3098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6039216, 0.9686275, 0.3921569)
        /// </summary>
        public static Color LightGrassGreen { get; } = new Color(0.6039216f, 0.9686275f, 0.3921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3607843, 0.6745098, 0.1764706)
        /// </summary>
        public static Color Grass { get; } = new Color(0.3607843f, 0.6745098f, 0.1764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0.9960784, 0.03137255)
        /// </summary>
        public static Color BrightLimeGreen { get; } = new Color(0.3960784f, 0.9960784f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4666667, 0.6705883, 0.3372549)
        /// </summary>
        public static Color Asparagus { get; } = new Color(0.4666667f, 0.6705883f, 0.3372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.254902, 0.6117647, 0.01176471)
        /// </summary>
        public static Color GrassyGreen { get; } = new Color(0.254902f, 0.6117647f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6627451, 0.9764706, 0.4431373)
        /// </summary>
        public static Color SpringGreen { get; } = new Color(0.6627451f, 0.9764706f, 0.4431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2196078, 0.5019608, 0.01568628)
        /// </summary>
        public static Color DarkGrassGreen { get; } = new Color(0.2196078f, 0.5019608f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7568628, 0.9921569, 0.5843138)
        /// </summary>
        public static Color Celery { get; } = new Color(0.7568628f, 0.9921569f, 0.5843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4392157, 0.6980392, 0.2470588)
        /// </summary>
        public static Color NastyGreen { get; } = new Color(0.4392157f, 0.6980392f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3019608, 0.6431373, 0.03529412)
        /// </summary>
        public static Color LawnGreen { get; } = new Color(0.3019608f, 0.6431373f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.682353, 1, 0.4313726)
        /// </summary>
        public static Color KeyLime { get; } = new Color(0.682353f, 1f, 0.4313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.345098, 0.7372549, 0.03137255)
        /// </summary>
        public static Color FrogGreen { get; } = new Color(0.345098f, 0.7372549f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.682353, 0.9921569, 0.4235294)
        /// </summary>
        public static Color LightLime { get; } = new Color(0.682353f, 0.9921569f, 0.4235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4627451, 0.6, 0.345098)
        /// </summary>
        public static Color Moss { get; } = new Color(0.4627451f, 0.6f, 0.345098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5568628, 0.8980392, 0.2470588)
        /// </summary>
        public static Color KiwiGreen { get; } = new Color(0.5568628f, 0.8980392f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7529412, 0.9803922, 0.5450981)
        /// </summary>
        public static Color Pistachio { get; } = new Color(0.7529412f, 0.9803922f, 0.5450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4627451, 0.8039216, 0.1490196)
        /// </summary>
        public static Color AppleGreen { get; } = new Color(0.4627451f, 0.8039216f, 0.1490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7607843, 1, 0.5372549)
        /// </summary>
        public static Color LightYellowishGreen { get; } = new Color(0.7607843f, 1f, 0.5372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6941177, 1, 0.3960784)
        /// </summary>
        public static Color PaleLimeGreen { get; } = new Color(0.6941177f, 1f, 0.3960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.454902, 0.5843138, 0.3176471)
        /// </summary>
        public static Color DrabGreen { get; } = new Color(0.454902f, 0.5843138f, 0.3176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3607843, 0.6980392, 0)
        /// </summary>
        public static Color KermitGreen { get; } = new Color(0.3607843f, 0.6980392f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4431373, 0.6666667, 0.2039216)
        /// </summary>
        public static Color Leaf { get; } = new Color(0.4431373f, 0.6666667f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6117647, 0.9372549, 0.2627451)
        /// </summary>
        public static Color Kiwi { get; } = new Color(0.6117647f, 0.9372549f, 0.2627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5294118, 0.9921569, 0.01960784)
        /// </summary>
        public static Color BrightLime { get; } = new Color(0.5294118f, 0.9921569f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5372549, 0.9960784, 0.01960784)
        /// </summary>
        public static Color LimeGreen { get; } = new Color(0.5372549f, 0.9960784f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7686275, 0.9960784, 0.509804)
        /// </summary>
        public static Color LightPeaGreen { get; } = new Color(0.7686275f, 0.9960784f, 0.509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3607843, 0.6627451, 0.01568628)
        /// </summary>
        public static Color LeafGreen { get; } = new Color(0.3607843f, 0.6627451f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0.5450981, 0.2196078)
        /// </summary>
        public static Color MossGreen { get; } = new Color(0.3960784f, 0.5450981f, 0.2196078f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7254902, 1, 0.4)
        /// </summary>
        public static Color LightLimeGreen { get; } = new Color(0.7254902f, 1f, 0.4f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7450981, 0.9921569, 0.4509804)
        /// </summary>
        public static Color PaleLime { get; } = new Color(0.7450981f, 0.9921569f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.9960784, 0.03529412)
        /// </summary>
        public static Color AcidGreen { get; } = new Color(0.5607843f, 0.9960784f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6666667, 1, 0.1960784)
        /// </summary>
        public static Color Lime { get; } = new Color(0.6666667f, 1f, 0.1960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2078431, 0.3254902, 0.03921569)
        /// </summary>
        public static Color NavyGreen { get; } = new Color(0.2078431f, 0.3254902f, 0.03921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6509804, 0.7843137, 0.4588235)
        /// </summary>
        public static Color LightMossGreen { get; } = new Color(0.6509804f, 0.7843137f, 0.4588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3882353, 0.5450981, 0.1529412)
        /// </summary>
        public static Color MossyGreen { get; } = new Color(0.3882353f, 0.5450981f, 0.1529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3607843, 0.5450981, 0.08235294)
        /// </summary>
        public static Color SapGreen { get; } = new Color(0.3607843f, 0.5450981f, 0.08235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8, 0.9921569, 0.4980392)
        /// </summary>
        public static Color LightYellowGreen { get; } = new Color(0.8f, 0.9921569f, 0.4980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 1, 0)
        /// </summary>
        public static Color BrightYellowGreen { get; } = new Color(0.6156863f, 1f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6941177, 0.8235294, 0.4823529)
        /// </summary>
        public static Color PaleOliveGreen { get; } = new Color(0.6941177f, 0.8235294f, 0.4823529f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4, 0.4862745, 0.2431373)
        /// </summary>
        public static Color MilitaryGreen { get; } = new Color(0.4f, 0.4862745f, 0.2431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4117647, 0.5137255, 0.2235294)
        /// </summary>
        public static Color Swamp { get; } = new Color(0.4117647f, 0.5137255f, 0.2235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 1, 0.01568628)
        /// </summary>
        public static Color ElectricLime { get; } = new Color(0.6588235f, 1f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4941176, 0.7411765, 0.003921569)
        /// </summary>
        public static Color DarkLimeGreen { get; } = new Color(0.4941176f, 0.7411765f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6784314, 0.972549, 0.007843138)
        /// </summary>
        public static Color LemonGreen { get; } = new Color(0.6784314f, 0.972549f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3215686, 0.3960784, 0.145098)
        /// </summary>
        public static Color CamoGreen { get; } = new Color(0.3215686f, 0.3960784f, 0.145098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7490196, 0.9960784, 0.1568628)
        /// </summary>
        public static Color LemonLime { get; } = new Color(0.7490196f, 0.9960784f, 0.1568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0.972549, 0.372549)
        /// </summary>
        public static Color Pear { get; } = new Color(0.7960784f, 0.972549f, 0.372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4, 0.4941176, 0.172549)
        /// </summary>
        public static Color DirtyGreen { get; } = new Color(0.4f, 0.4941176f, 0.172549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7529412, 0.9843137, 0.1764706)
        /// </summary>
        public static Color YellowGreen { get; } = new Color(0.7529412f, 0.9843137f, 0.1764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2941177, 0.3803922, 0.07450981)
        /// </summary>
        public static Color CamouflageGreen { get; } = new Color(0.2941177f, 0.3803922f, 0.07450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5176471, 0.7176471, 0.003921569)
        /// </summary>
        public static Color DarkLime { get; } = new Color(0.5176471f, 0.7176471f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.9921569, 0.2392157)
        /// </summary>
        public static Color Yellow_Green { get; } = new Color(0.7843137f, 0.9921569f, 0.2392157f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6627451, 0.7450981, 0.4392157)
        /// </summary>
        public static Color TanGreen { get; } = new Color(0.6627451f, 0.7450981f, 0.4392157f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6431373, 0.7450981, 0.3607843)
        /// </summary>
        public static Color LightOliveGreen { get; } = new Color(0.6431373f, 0.7450981f, 0.3607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7333333, 0.9764706, 0.05882353)
        /// </summary>
        public static Color Yellowgreen { get; } = new Color(0.7333333f, 0.9764706f, 0.05882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5647059, 0.6941177, 0.2039216)
        /// </summary>
        public static Color Avocado { get; } = new Color(0.5647059f, 0.6941177f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4470588, 0.5254902, 0.2235294)
        /// </summary>
        public static Color KhakiGreen { get; } = new Color(0.4470588f, 0.5254902f, 0.2235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6, 0.8, 0.01568628)
        /// </summary>
        public static Color SlimeGreen { get; } = new Color(0.6f, 0.8f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2941177, 0.3647059, 0.08627451)
        /// </summary>
        public static Color ArmyGreen { get; } = new Color(0.2941177f, 0.3647059f, 0.08627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7254902, 0.8, 0.5058824)
        /// </summary>
        public static Color PaleOlive { get; } = new Color(0.7254902f, 0.8f, 0.5058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5294118, 0.6627451, 0.1333333)
        /// </summary>
        public static Color AvocadoGreen { get; } = new Color(0.5294118f, 0.6627451f, 0.1333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7882353, 1, 0.1529412)
        /// </summary>
        public static Color GreenYellow { get; } = new Color(0.7882353f, 1f, 0.1529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7490196, 0.945098, 0.1568628)
        /// </summary>
        public static Color YellowyGreen { get; } = new Color(0.7490196f, 0.945098f, 0.1568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.5607843, 0.3058824)
        /// </summary>
        public static Color Camo { get; } = new Color(0.4980392f, 0.5607843f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7568628, 0.972549, 0.03921569)
        /// </summary>
        public static Color Chartreuse { get; } = new Color(0.7568628f, 0.972549f, 0.03921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2352941, 0.3019608, 0.01176471)
        /// </summary>
        public static Color DarkOliveGreen { get; } = new Color(0.2352941f, 0.3019608f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0.454902, 0.1960784)
        /// </summary>
        public static Color MuddyGreen { get; } = new Color(0.3960784f, 0.454902f, 0.1960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6901961, 0.8666667, 0.08627451)
        /// </summary>
        public static Color YellowishGreen { get; } = new Color(0.6901961f, 0.8666667f, 0.08627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.682353, 0.1333333)
        /// </summary>
        public static Color IckyGreen { get; } = new Color(0.5607843f, 0.682353f, 0.1333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.7490196, 0.4117647)
        /// </summary>
        public static Color LightOlive { get; } = new Color(0.6745098f, 0.7490196f, 0.4117647f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6078432, 0.7098039, 0.2352941)
        /// </summary>
        public static Color Booger { get; } = new Color(0.6078432f, 0.7098039f, 0.2352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7764706, 0.972549, 0.03137255)
        /// </summary>
        public static Color GreenyYellow { get; } = new Color(0.7764706f, 0.972549f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4470588, 0.5607843, 0.007843138)
        /// </summary>
        public static Color DarkYellowGreen { get; } = new Color(0.4470588f, 0.5607843f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8156863, 0.9960784, 0.1137255)
        /// </summary>
        public static Color LimeYellow { get; } = new Color(0.8156863f, 0.9960784f, 0.1137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5803922, 0.6980392, 0.1098039)
        /// </summary>
        public static Color SicklyGreen { get; } = new Color(0.5803922f, 0.6980392f, 0.1098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 0.7254902, 0.172549)
        /// </summary>
        public static Color SickGreen { get; } = new Color(0.6156863f, 0.7254902f, 0.172549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4784314, 0.5921569, 0.01176471)
        /// </summary>
        public static Color UglyGreen { get; } = new Color(0.4784314f, 0.5921569f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8039216, 0.9921569, 0.007843138)
        /// </summary>
        public static Color GreenishYellow { get; } = new Color(0.8039216f, 0.9921569f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8117647, 1, 0.01568628)
        /// </summary>
        public static Color NeonYellow { get; } = new Color(0.8117647f, 1f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5568628, 0.6705883, 0.07058824)
        /// </summary>
        public static Color PeaGreen { get; } = new Color(0.5568628f, 0.6705883f, 0.07058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 0.7568628, 0)
        /// </summary>
        public static Color SnotGreen { get; } = new Color(0.6156863f, 0.7568628f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7372549, 0.7960784, 0.4784314)
        /// </summary>
        public static Color GreenishTan { get; } = new Color(0.7372549f, 0.7960784f, 0.4784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.627451, 0.7490196, 0.08627451)
        /// </summary>
        public static Color GrossGreen { get; } = new Color(0.627451f, 0.7490196f, 0.08627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6431373, 0.7490196, 0.1254902)
        /// </summary>
        public static Color Pea { get; } = new Color(0.6431373f, 0.7490196f, 0.1254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5882353, 0.7058824, 0.01176471)
        /// </summary>
        public static Color BoogerGreen { get; } = new Color(0.5882353f, 0.7058824f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6117647, 0.7333333, 0.01568628)
        /// </summary>
        public static Color BrightOlive { get; } = new Color(0.6117647f, 0.7333333f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4039216, 0.4784314, 0.01568628)
        /// </summary>
        public static Color OliveGreen { get; } = new Color(0.4039216f, 0.4784314f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5372549, 0.6352941, 0.01176471)
        /// </summary>
        public static Color VomitGreen { get; } = new Color(0.5372549f, 0.6352941f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9019608, 0.9490196, 0.6352941)
        /// </summary>
        public static Color LightKhaki { get; } = new Color(0.9019608f, 0.9490196f, 0.6352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5803922, 0.6745098, 0.007843138)
        /// </summary>
        public static Color BarfGreen { get; } = new Color(0.5803922f, 0.6745098f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4235294, 0.4784314, 0.05490196)
        /// </summary>
        public static Color MurkyGreen { get; } = new Color(0.4235294f, 0.4784314f, 0.05490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.454902, 0.5215687, 0)
        /// </summary>
        public static Color SwampGreen { get; } = new Color(0.454902f, 0.5215687f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7098039, 0.8078431, 0.03137255)
        /// </summary>
        public static Color Green_Yellow { get; } = new Color(0.7098039f, 0.8078431f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5803922, 0.6509804, 0.09019608)
        /// </summary>
        public static Color PeaSoupGreen { get; } = new Color(0.5803922f, 0.6509804f, 0.09019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6039216, 0.682353, 0.02745098)
        /// </summary>
        public static Color PukeGreen { get; } = new Color(0.6039216f, 0.682353f, 0.02745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5333334, 0.5921569, 0.09019608)
        /// </summary>
        public static Color BabyShitGreen { get; } = new Color(0.5333334f, 0.5921569f, 0.09019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2156863, 0.2431373, 0.007843138)
        /// </summary>
        public static Color DarkOlive { get; } = new Color(0.2156863f, 0.2431373f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8156863, 0.8941177, 0.1607843)
        /// </summary>
        public static Color SicklyYellow { get; } = new Color(0.8156863f, 0.8941177f, 0.1607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4352941, 0.4862745, 0)
        /// </summary>
        public static Color PoopGreen { get; } = new Color(0.4352941f, 0.4862745f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4352941, 0.4627451, 0.1960784)
        /// </summary>
        public static Color OliveDrab { get; } = new Color(0.4352941f, 0.4627451f, 0.1960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7882353, 0.8196079, 0.4745098)
        /// </summary>
        public static Color GreenishBeige { get; } = new Color(0.7882353f, 0.8196079f, 0.4745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.7333333, 0.05098039)
        /// </summary>
        public static Color Snot { get; } = new Color(0.6745098f, 0.7333333f, 0.05098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4588235, 0.5019608, 0)
        /// </summary>
        public static Color ShitGreen { get; } = new Color(0.4588235f, 0.5019608f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7098039, 0.7647059, 0.02352941)
        /// </summary>
        public static Color Bile { get; } = new Color(0.7098039f, 0.7647059f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7137255, 0.7686275, 0.02352941)
        /// </summary>
        public static Color BabyPukeGreen { get; } = new Color(0.7137255f, 0.7686275f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.7098039, 0.01568628)
        /// </summary>
        public static Color MustardGreen { get; } = new Color(0.6588235f, 0.7098039f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4313726, 0.4588235, 0.05490196)
        /// </summary>
        public static Color Olive { get; } = new Color(0.4313726f, 0.4588235f, 0.05490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.5960785, 0.01960784)
        /// </summary>
        public static Color BabyPoopGreen { get; } = new Color(0.5607843f, 0.5960785f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3764706, 0.4, 0.007843138)
        /// </summary>
        public static Color MudGreen { get; } = new Color(0.3764706f, 0.4f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.572549, 0.6, 0.003921569)
        /// </summary>
        public static Color PeaSoup { get; } = new Color(0.572549f, 0.6f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4156863, 0.4313726, 0.03529412)
        /// </summary>
        public static Color BrownishGreen { get; } = new Color(0.4156863f, 0.4313726f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9803922, 0.9960784, 0.2941177)
        /// </summary>
        public static Color BananaYellow { get; } = new Color(0.9803922f, 0.9960784f, 0.2941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 1, 0.7921569)
        /// </summary>
        public static Color Ecru { get; } = new Color(0.9960784f, 1f, 0.7921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.509804, 0.5137255, 0.2666667)
        /// </summary>
        public static Color Drab { get; } = new Color(0.509804f, 0.5137255f, 0.2666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6352941, 0.6431373, 0.08235294)
        /// </summary>
        public static Color Vomit { get; } = new Color(0.6352941f, 0.6431373f, 0.08235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 1, 0.3882353)
        /// </summary>
        public static Color Canary { get; } = new Color(0.9921569f, 1f, 0.3882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 1, 0.3215686)
        /// </summary>
        public static Color Lemon { get; } = new Color(0.9921569f, 1f, 0.3215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.945098, 0.9529412, 0.2470588)
        /// </summary>
        public static Color OffYellow { get; } = new Color(0.945098f, 0.9529412f, 0.2470588f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 1, 0.2196078)
        /// </summary>
        public static Color LemonYellow { get; } = new Color(0.9921569f, 1f, 0.2196078f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 1, 0.4980392)
        /// </summary>
        public static Color FadedYellow { get; } = new Color(0.9960784f, 1f, 0.4980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6470588, 0.6470588, 0.007843138)
        /// </summary>
        public static Color Puke { get; } = new Color(0.6470588f, 0.6470588f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.07843138)
        /// </summary>
        public static Color Yellow { get; } = new Color(1f, 1f, 0.07843138f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.4941176)
        /// </summary>
        public static Color Banana { get; } = new Color(1f, 1f, 0.4941176f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.5058824)
        /// </summary>
        public static Color Butter { get; } = new Color(1f, 1f, 0.5058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.9882353, 0.5058824)
        /// </summary>
        public static Color YellowishTan { get; } = new Color(0.9882353f, 0.9882353f, 0.5058824f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.5176471)
        /// </summary>
        public static Color PaleYellow { get; } = new Color(1f, 1f, 0.5176471f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.7137255)
        /// </summary>
        public static Color Creme { get; } = new Color(1f, 1f, 0.7137255f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.7607843)
        /// </summary>
        public static Color Cream { get; } = new Color(1f, 1f, 0.7607843f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.7960784)
        /// </summary>
        public static Color Ivory { get; } = new Color(1f, 1f, 0.7960784f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.8313726)
        /// </summary>
        public static Color Eggshell { get; } = new Color(1f, 1f, 0.8313726f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 0.8941177)
        /// </summary>
        public static Color OffWhite { get; } = new Color(1f, 1f, 0.8941177f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9960784, 0.2509804)
        /// </summary>
        public static Color CanaryYellow { get; } = new Color(1f, 0.9960784f, 0.2509804f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9960784, 0.4431373)
        /// </summary>
        public static Color PastelYellow { get; } = new Color(1f, 0.9960784f, 0.4431373f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9960784, 0.4784314)
        /// </summary>
        public static Color LightYellow { get; } = new Color(1f, 0.9960784f, 0.4784314f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9921569, 0.003921569)
        /// </summary>
        public static Color BrightYellow { get; } = new Color(1f, 0.9921569f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9921569, 0.2156863)
        /// </summary>
        public static Color SunshineYellow { get; } = new Color(1f, 0.9921569f, 0.2156863f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9960784, 0.7137255)
        /// </summary>
        public static Color LightBeige { get; } = new Color(1f, 0.9960784f, 0.7137255f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9921569, 0.454902)
        /// </summary>
        public static Color ButterYellow { get; } = new Color(1f, 0.9921569f, 0.454902f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9921569, 0.4705882)
        /// </summary>
        public static Color Custard { get; } = new Color(1f, 0.9921569f, 0.4705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7607843, 0.7450981, 0.05490196)
        /// </summary>
        public static Color PukeYellow { get; } = new Color(0.7607843f, 0.7450981f, 0.05490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.9882353, 0.6862745)
        /// </summary>
        public static Color Parchment { get; } = new Color(0.9960784f, 0.9882353f, 0.6862745f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9764706, 0.09019608)
        /// </summary>
        public static Color SunnyYellow { get; } = new Color(1f, 0.9764706f, 0.09019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4352941, 0.4235294, 0.03921569)
        /// </summary>
        public static Color BrownyGreen { get; } = new Color(0.4352941f, 0.4235294f, 0.03921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7803922, 0.7568628, 0.04705882)
        /// </summary>
        public static Color VomitYellow { get; } = new Color(0.7803922f, 0.7568628f, 0.04705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8666667, 0.8392157, 0.09411765)
        /// </summary>
        public static Color PissYellow { get; } = new Color(0.8666667f, 0.8392157f, 0.09411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8039216, 0.772549, 0.03921569)
        /// </summary>
        public static Color DirtyYellow { get; } = new Color(0.8039216f, 0.772549f, 0.03921569f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9803922, 0.5254902)
        /// </summary>
        public static Color Manilla { get; } = new Color(1f, 0.9803922f, 0.5254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4392157, 0.4235294, 0.06666667)
        /// </summary>
        public static Color BrownGreen { get; } = new Color(0.4392157f, 0.4235294f, 0.06666667f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.9647059, 0.4745098)
        /// </summary>
        public static Color Straw { get; } = new Color(0.9882353f, 0.9647059f, 0.4745098f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9882353, 0.7686275)
        /// </summary>
        public static Color EggShell { get; } = new Color(1f, 0.9882353f, 0.7686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6666667, 0.6509804, 0.3843137)
        /// </summary>
        public static Color Khaki { get; } = new Color(0.6666667f, 0.6509804f, 0.3843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7607843, 0.7176471, 0.03529412)
        /// </summary>
        public static Color OliveYellow { get; } = new Color(0.7607843f, 0.7176471f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8156863, 0.7568628, 0.003921569)
        /// </summary>
        public static Color UglyYellow { get; } = new Color(0.8156863f, 0.7568628f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3294118, 0.3058824, 0.01176471)
        /// </summary>
        public static Color GreenBrown { get; } = new Color(0.3294118f, 0.3058824f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9803922, 0.9333333, 0.4)
        /// </summary>
        public static Color Yellowish { get; } = new Color(0.9803922f, 0.9333333f, 0.4f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.9647059, 0.6196079)
        /// </summary>
        public static Color Buff { get; } = new Color(0.9960784f, 0.9647059f, 0.6196079f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4117647, 0.3764706, 0.02352941)
        /// </summary>
        public static Color GreenyBrown { get; } = new Color(0.4117647f, 0.3764706f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4117647, 0.3803922, 0.07058824)
        /// </summary>
        public static Color GreenishBrown { get; } = new Color(0.4117647f, 0.3803922f, 0.07058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4901961, 0.4431373, 0.01176471)
        /// </summary>
        public static Color UglyBrown { get; } = new Color(0.4901961f, 0.4431373f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6470588, 0.6392157, 0.5686275)
        /// </summary>
        public static Color Cement { get; } = new Color(0.6470588f, 0.6392157f, 0.5686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7490196, 0.6745098, 0.01960784)
        /// </summary>
        public static Color MuddyYellow { get; } = new Color(0.7490196f, 0.6745098f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8235294, 0.7411765, 0.03921569)
        /// </summary>
        public static Color MustardYellow { get; } = new Color(0.8235294f, 0.7411765f, 0.03921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.9333333, 0.4509804)
        /// </summary>
        public static Color SandyYellow { get; } = new Color(0.9921569f, 0.9333333f, 0.4509804f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9529412, 0.6039216)
        /// </summary>
        public static Color DarkCream { get; } = new Color(1f, 0.9529412f, 0.6039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9333333, 0.8627451, 0.3568628)
        /// </summary>
        public static Color DullYellow { get; } = new Color(0.9333333f, 0.8627451f, 0.3568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.8745098, 0.03137255)
        /// </summary>
        public static Color Dandelion { get; } = new Color(0.9960784f, 0.8745098f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7882353, 0.6901961, 0.01176471)
        /// </summary>
        public static Color BrownishYellow { get; } = new Color(0.7882353f, 0.6901961f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9764706, 0.8156863)
        /// </summary>
        public static Color Pale { get; } = new Color(1f, 0.9764706f, 0.8156863f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8078431, 0.7019608, 0.003921569)
        /// </summary>
        public static Color Mustard { get; } = new Color(0.8078431f, 0.7019608f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.8745098, 0.1333333)
        /// </summary>
        public static Color SunYellow { get; } = new Color(1f, 0.8745098f, 0.1333333f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.854902, 0.01176471)
        /// </summary>
        public static Color SunflowerYellow { get; } = new Color(1f, 0.854902f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8352941, 0.7137255, 0.03921569)
        /// </summary>
        public static Color DarkYellow { get; } = new Color(0.8352941f, 0.7137255f, 0.03921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6980392, 0.5921569, 0.01960784)
        /// </summary>
        public static Color BrownYellow { get; } = new Color(0.6980392f, 0.5921569f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5764706, 0.4862745, 0)
        /// </summary>
        public static Color BabyPoop { get; } = new Color(0.5764706f, 0.4862745f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6705883, 0.5647059, 0.01568628)
        /// </summary>
        public static Color BabyPoo { get; } = new Color(0.6705883f, 0.5647059f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9843137, 0.9333333, 0.6745098)
        /// </summary>
        public static Color LightTan { get; } = new Color(0.9843137f, 0.9333333f, 0.6745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3921569, 0.3294118, 0.01176471)
        /// </summary>
        public static Color OliveBrown { get; } = new Color(0.3921569f, 0.3294118f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6078432, 0.5607843, 0.3333333)
        /// </summary>
        public static Color DarkKhaki { get; } = new Color(0.6078432f, 0.5607843f, 0.3333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6235294, 0.5137255, 0.01176471)
        /// </summary>
        public static Color Diarrhea { get; } = new Color(0.6235294f, 0.5137255f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.8823529, 0.4)
        /// </summary>
        public static Color SandYellow { get; } = new Color(0.9882353f, 0.8823529f, 0.4f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6784314, 0.5647059, 0.05098039)
        /// </summary>
        public static Color BabyShitBrown { get; } = new Color(0.6784314f, 0.5647059f, 0.05098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9019608, 0.854902, 0.6509804)
        /// </summary>
        public static Color Beige { get; } = new Color(0.9019608f, 0.854902f, 0.6509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8588235, 0.7058824, 0.04705882)
        /// </summary>
        public static Color Gold { get; } = new Color(0.8588235f, 0.7058824f, 0.04705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.5372549, 0.01960784)
        /// </summary>
        public static Color DarkMustard { get; } = new Color(0.6588235f, 0.5372549f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7176471, 0.5803922, 0)
        /// </summary>
        public static Color YellowBrown { get; } = new Color(0.7176471f, 0.5803922f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.8901961, 0.4313726)
        /// </summary>
        public static Color YellowTan { get; } = new Color(1f, 0.8901961f, 0.4313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.945098, 0.854902, 0.4784314)
        /// </summary>
        public static Color Sandy { get; } = new Color(0.945098f, 0.854902f, 0.4784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6862745, 0.6588235, 0.5450981)
        /// </summary>
        public static Color Bland { get; } = new Color(0.6862745f, 0.6588235f, 0.5450981f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7098039, 0.5803922, 0.0627451)
        /// </summary>
        public static Color DarkGold { get; } = new Color(0.7098039f, 0.5803922f, 0.0627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.4509804, 0.01176471)
        /// </summary>
        public static Color Poo { get; } = new Color(0.5607843f, 0.4509804f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7490196, 0.6078432, 0.04705882)
        /// </summary>
        public static Color Ocher { get; } = new Color(0.7490196f, 0.6078432f, 0.04705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5568628, 0.4627451, 0.09411765)
        /// </summary>
        public static Color Hazel { get; } = new Color(0.5568628f, 0.4627451f, 0.09411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5803922, 0.4666667, 0.02352941)
        /// </summary>
        public static Color PukeBrown { get; } = new Color(0.5803922f, 0.4666667f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.8627451, 0.3607843)
        /// </summary>
        public static Color LightGold { get; } = new Color(0.9921569f, 0.8627451f, 0.3607843f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8352941, 0.6705883, 0.03529412)
        /// </summary>
        public static Color BurntYellow { get; } = new Color(0.8352941f, 0.6705883f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6784314, 0.6470588, 0.5294118)
        /// </summary>
        public static Color Stone { get; } = new Color(0.6784314f, 0.6470588f, 0.5294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.6431373, 0.5843138)
        /// </summary>
        public static Color Greyish { get; } = new Color(0.6588235f, 0.6431373f, 0.5843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.8705882, 0.4235294)
        /// </summary>
        public static Color PaleGold { get; } = new Color(0.9921569f, 0.8705882f, 0.4235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6078432, 0.4784314, 0.003921569)
        /// </summary>
        public static Color YellowishBrown { get; } = new Color(0.6078432f, 0.4784314f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.682353, 0.5450981, 0.04705882)
        /// </summary>
        public static Color YellowyBrown { get; } = new Color(0.682353f, 0.5450981f, 0.04705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7764706, 0.6117647, 0.01568628)
        /// </summary>
        public static Color Ocre { get; } = new Color(0.7764706f, 0.6117647f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8862745, 0.7921569, 0.4627451)
        /// </summary>
        public static Color Sand { get; } = new Color(0.8862745f, 0.7921569f, 0.4627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9607843, 0.7490196, 0.01176471)
        /// </summary>
        public static Color Golden { get; } = new Color(0.9607843f, 0.7490196f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9568627, 0.8156863, 0.3294118)
        /// </summary>
        public static Color Maize { get; } = new Color(0.9568627f, 0.8156863f, 0.3294118f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9686275, 0.8352941, 0.3764706)
        /// </summary>
        public static Color LightMustard { get; } = new Color(0.9686275f, 0.8352941f, 0.3764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9803922, 0.7607843, 0.01960784)
        /// </summary>
        public static Color Goldenrod { get; } = new Color(0.9803922f, 0.7607843f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0.6156863, 0.02352941)
        /// </summary>
        public static Color YellowOchre { get; } = new Color(0.7960784f, 0.6156863f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4509804, 0.3607843, 0.07058824)
        /// </summary>
        public static Color Mud { get; } = new Color(0.4509804f, 0.3607843f, 0.07058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9843137, 0.8666667, 0.4941176)
        /// </summary>
        public static Color Wheat { get; } = new Color(0.9843137f, 0.8666667f, 0.4941176f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.7764706, 0.08235294)
        /// </summary>
        public static Color GoldenYellow { get; } = new Color(0.9960784f, 0.7764706f, 0.08235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5529412, 0.5176471, 0.4078431)
        /// </summary>
        public static Color BrownGrey { get; } = new Color(0.5529412f, 0.5176471f, 0.4078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.7529412, 0.02352941)
        /// </summary>
        public static Color Marigold { get; } = new Color(0.9882353f, 0.7529412f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.772549, 0.07058824)
        /// </summary>
        public static Color Sunflower { get; } = new Color(1f, 0.772549f, 0.07058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5333334, 0.4078431, 0.02352941)
        /// </summary>
        public static Color MuddyBrown { get; } = new Color(0.5333334f, 0.4078431f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.372549, 0)
        /// </summary>
        public static Color Shit { get; } = new Color(0.4980392f, 0.372549f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7490196, 0.5647059, 0.01960784)
        /// </summary>
        public static Color Ochre { get; } = new Color(0.7490196f, 0.5647059f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9764706, 0.7372549, 0.03137255)
        /// </summary>
        public static Color GoldenRod { get; } = new Color(0.9764706f, 0.7372549f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.3686275, 0)
        /// </summary>
        public static Color Poop { get; } = new Color(0.4980392f, 0.3686275f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4784314, 0.3490196, 0.003921569)
        /// </summary>
        public static Color PoopBrown { get; } = new Color(0.4784314f, 0.3490196f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.4941176, 0.01568628)
        /// </summary>
        public static Color MustardBrown { get; } = new Color(0.6745098f, 0.4941176f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.4745098, 0)
        /// </summary>
        public static Color Bronze { get; } = new Color(0.6588235f, 0.4745098f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8, 0.6784314, 0.3764706)
        /// </summary>
        public static Color Desert { get; } = new Color(0.8f, 0.6784314f, 0.3764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.7254902, 0.08235294)
        /// </summary>
        public static Color OrangeyYellow { get; } = new Color(0.9921569f, 0.7254902f, 0.08235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4823529, 0.345098, 0.01568628)
        /// </summary>
        public static Color ShitBrown { get; } = new Color(0.4823529f, 0.345098f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.6901961, 0.003921569)
        /// </summary>
        public static Color YellowOrange { get; } = new Color(0.9882353f, 0.6901961f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7686275, 0.6509804, 0.3803922)
        /// </summary>
        public static Color SandyBrown { get; } = new Color(0.7686275f, 0.6509804f, 0.3803922f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5333334, 0.372549, 0.003921569)
        /// </summary>
        public static Color PooBrown { get; } = new Color(0.5333334f, 0.372549f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.7019608, 0.03137255)
        /// </summary>
        public static Color Amber { get; } = new Color(0.9960784f, 0.7019608f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7450981, 0.682353, 0.5411765)
        /// </summary>
        public static Color Putty { get; } = new Color(0.7450981f, 0.682353f, 0.5411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.6980392, 0.03529412)
        /// </summary>
        public static Color Saffron { get; } = new Color(0.9960784f, 0.6980392f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8196079, 0.6980392, 0.4352941)
        /// </summary>
        public static Color Tan { get; } = new Color(0.8196079f, 0.6980392f, 0.4352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6980392, 0.4784314, 0.003921569)
        /// </summary>
        public static Color GoldenBrown { get; } = new Color(0.6980392f, 0.4784314f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.5607843, 0.3490196)
        /// </summary>
        public static Color DarkSand { get; } = new Color(0.6588235f, 0.5607843f, 0.3490196f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.8980392, 0.6784314)
        /// </summary>
        public static Color PalePeach { get; } = new Color(1f, 0.8980392f, 0.6784314f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9372549, 0.7058824, 0.2078431)
        /// </summary>
        public static Color MacaroniAndCheese { get; } = new Color(0.9372549f, 0.7058824f, 0.2078431f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7882353, 0.682353, 0.454902)
        /// </summary>
        public static Color Sandstone { get; } = new Color(0.7882353f, 0.682353f, 0.454902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3764706, 0.2745098, 0.05882353)
        /// </summary>
        public static Color MudBrown { get; } = new Color(0.3764706f, 0.2745098f, 0.05882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9490196, 0.6705883, 0.08235294)
        /// </summary>
        public static Color Squash { get; } = new Color(0.9490196f, 0.6705883f, 0.08235294f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6784314, 0.003921569)
        /// </summary>
        public static Color OrangeYellow { get; } = new Color(1f, 0.6784314f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.5764706, 0.3843137)
        /// </summary>
        public static Color DarkBeige { get; } = new Color(0.6745098f, 0.5764706f, 0.3843137f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.4392157, 0.3254902)
        /// </summary>
        public static Color GreyBrown { get; } = new Color(0.4980392f, 0.4392157f, 0.3254902f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6705883, 0.05882353)
        /// </summary>
        public static Color YellowishOrange { get; } = new Color(1f, 0.6705883f, 0.05882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0.6470588, 0.3764706)
        /// </summary>
        public static Color SandBrown { get; } = new Color(0.7960784f, 0.6470588f, 0.3764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7764706, 0.6235294, 0.3490196)
        /// </summary>
        public static Color Camel { get; } = new Color(0.7764706f, 0.6235294f, 0.3490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.827451, 0.7137255, 0.5137255)
        /// </summary>
        public static Color VeryLightBrown { get; } = new Color(0.827451f, 0.7137255f, 0.5137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6039216, 0.3843137, 0)
        /// </summary>
        public static Color RawSienna { get; } = new Color(0.6039216f, 0.3843137f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7803922, 0.6745098, 0.4901961)
        /// </summary>
        public static Color Toupe { get; } = new Color(0.7803922f, 0.6745098f, 0.4901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6980392, 0.6, 0.4313726)
        /// </summary>
        public static Color Dust { get; } = new Color(0.6980392f, 0.6f, 0.4313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4784314, 0.4156863, 0.3098039)
        /// </summary>
        public static Color GreyishBrown { get; } = new Color(0.4784314f, 0.4156863f, 0.3098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8117647, 0.6862745, 0.4823529)
        /// </summary>
        public static Color Fawn { get; } = new Color(0.8117647f, 0.6862745f, 0.4823529f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5254902, 0.4666667, 0.372549)
        /// </summary>
        public static Color BrownishGrey { get; } = new Color(0.5254902f, 0.4666667f, 0.372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6862745, 0.4352941, 0.03529412)
        /// </summary>
        public static Color Caramel { get; } = new Color(0.6862745f, 0.4352941f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6862745, 0.5333334, 0.2901961)
        /// </summary>
        public static Color DarkTan { get; } = new Color(0.6862745f, 0.5333334f, 0.2901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5137255, 0.3960784, 0.2235294)
        /// </summary>
        public static Color DirtBrown { get; } = new Color(0.5137255f, 0.3960784f, 0.2235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5411765, 0.4313726, 0.2705882)
        /// </summary>
        public static Color Dirt { get; } = new Color(0.5411765f, 0.4313726f, 0.2705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7254902, 0.6352941, 0.5058824)
        /// </summary>
        public static Color Taupe { get; } = new Color(0.7254902f, 0.6352941f, 0.5058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6509804, 0.5058824, 0.2980392)
        /// </summary>
        public static Color Coffee { get; } = new Color(0.6509804f, 0.5058824f, 0.2980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5294118, 0.4313726, 0.2941177)
        /// </summary>
        public static Color DullBrown { get; } = new Color(0.5294118f, 0.4313726f, 0.2941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.6941177, 0.2784314)
        /// </summary>
        public static Color Butterscotch { get; } = new Color(0.9921569f, 0.6941177f, 0.2784314f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6509804, 0.1686275)
        /// </summary>
        public static Color Mango { get; } = new Color(1f, 0.6509804f, 0.1686275f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.3176471, 0.07058824)
        /// </summary>
        public static Color MediumBrown { get; } = new Color(0.4980392f, 0.3176471f, 0.07058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.4627451, 0.02352941)
        /// </summary>
        public static Color DirtyOrange { get; } = new Color(0.7843137f, 0.4627451f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.5803922, 0.03137255)
        /// </summary>
        public static Color Tangerine { get; } = new Color(1f, 0.5803922f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7254902, 0.4117647, 0.007843138)
        /// </summary>
        public static Color BrownOrange { get; } = new Color(0.7254902f, 0.4117647f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6980392, 0.3921569, 0)
        /// </summary>
        public static Color Umber { get; } = new Color(0.6980392f, 0.3921569f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.3960784, 0.2156863, 0)
        /// </summary>
        public static Color Brown { get; } = new Color(0.3960784f, 0.2156863f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.6666667, 0.282353)
        /// </summary>
        public static Color LightOrange { get; } = new Color(0.9921569f, 0.6666667f, 0.282353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.654902, 0.3686275, 0.03529412)
        /// </summary>
        public static Color RawUmber { get; } = new Color(0.654902f, 0.3686275f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6941177, 0.3764706, 0.007843138)
        /// </summary>
        public static Color OrangeyBrown { get; } = new Color(0.6941177f, 0.3764706f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.454902, 0.2039216)
        /// </summary>
        public static Color Leather { get; } = new Color(0.6745098f, 0.454902f, 0.2039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.4078431, 0.3058824)
        /// </summary>
        public static Color DarkTaupe { get; } = new Color(0.4980392f, 0.4078431f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6470588, 0.4941176, 0.3215686)
        /// </summary>
        public static Color Puce { get; } = new Color(0.6470588f, 0.4941176f, 0.3215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6784314, 0.5058824, 0.3137255)
        /// </summary>
        public static Color LightBrown { get; } = new Color(0.6784314f, 0.5058824f, 0.3137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8823529, 0.4666667, 0.003921569)
        /// </summary>
        public static Color Pumpkin { get; } = new Color(0.8823529f, 0.4666667f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7450981, 0.3921569, 0)
        /// </summary>
        public static Color OrangeBrown { get; } = new Color(0.7450981f, 0.3921569f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6705883, 0.4941176, 0.2980392)
        /// </summary>
        public static Color TanBrown { get; } = new Color(0.6705883f, 0.4941176f, 0.2980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6980392, 0.372549, 0.01176471)
        /// </summary>
        public static Color OrangishBrown { get; } = new Color(0.6980392f, 0.372549f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7921569, 0.4196078, 0.007843138)
        /// </summary>
        public static Color BrownyOrange { get; } = new Color(0.7921569f, 0.4196078f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6941177, 0.5686275, 0.4313726)
        /// </summary>
        public static Color PaleBrown { get; } = new Color(0.6941177f, 0.5686275f, 0.4313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2039216, 0.1098039, 0.007843138)
        /// </summary>
        public static Color DarkBrown { get; } = new Color(0.2039216f, 0.1098039f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5882353, 0.3058824, 0.007843138)
        /// </summary>
        public static Color WarmBrown { get; } = new Color(0.5882353f, 0.3058824f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0.4666667, 0.1372549)
        /// </summary>
        public static Color BrownishOrange { get; } = new Color(0.7960784f, 0.4666667f, 0.1372549f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.8470588, 0.6941177)
        /// </summary>
        public static Color LightPeach { get; } = new Color(1f, 0.8470588f, 0.6941177f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.3058824, 0.1176471)
        /// </summary>
        public static Color MilkChocolate { get; } = new Color(0.4980392f, 0.3058824f, 0.1176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6156863, 0.4627451, 0.3176471)
        /// </summary>
        public static Color Mocha { get; } = new Color(0.6156863f, 0.4627451f, 0.3176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9843137, 0.4901961, 0.02745098)
        /// </summary>
        public static Color PumpkinOrange { get; } = new Color(0.9843137f, 0.4901961f, 0.02745098f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.654902, 0.3372549)
        /// </summary>
        public static Color PaleOrange { get; } = new Color(1f, 0.654902f, 0.3372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8470588, 0.5254902, 0.2313726)
        /// </summary>
        public static Color DullOrange { get; } = new Color(0.8470588f, 0.5254902f, 0.2313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5960785, 0.3686275, 0.1686275)
        /// </summary>
        public static Color Sepia { get; } = new Color(0.5960785f, 0.3686275f, 0.1686275f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6941177, 0.427451)
        /// </summary>
        public static Color Apricot { get; } = new Color(1f, 0.6941177f, 0.427451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9764706, 0.4509804, 0.02352941)
        /// </summary>
        public static Color Orange { get; } = new Color(0.9764706f, 0.4509804f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6980392, 0.4431373, 0.2392157)
        /// </summary>
        public static Color ClayBrown { get; } = new Color(0.6980392f, 0.4431373f, 0.2392157f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2392157, 0.1098039, 0.007843138)
        /// </summary>
        public static Color Chocolate { get; } = new Color(0.2392157f, 0.1098039f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7294118, 0.6196079, 0.5333334)
        /// </summary>
        public static Color Mushroom { get; } = new Color(0.7294118f, 0.6196079f, 0.5333334f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6745098, 0.3098039, 0.02352941)
        /// </summary>
        public static Color Cinnamon { get; } = new Color(0.6745098f, 0.3098039f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7176471, 0.3215686, 0.01176471)
        /// </summary>
        public static Color BurntSiena { get; } = new Color(0.7176471f, 0.3215686f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9411765, 0.5803922, 0.3019608)
        /// </summary>
        public static Color FadedOrange { get; } = new Color(0.9411765f, 0.5803922f, 0.3019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7137255, 0.3882353, 0.145098)
        /// </summary>
        public static Color Copper { get; } = new Color(0.7137255f, 0.3882353f, 0.145098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5294118, 0.372549, 0.2588235)
        /// </summary>
        public static Color Cocoa { get; } = new Color(0.5294118f, 0.372549f, 0.2588235f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7686275, 0.3333333, 0.03137255)
        /// </summary>
        public static Color RustOrange { get; } = new Color(0.7686275f, 0.3333333f, 0.03137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8039216, 0.3490196, 0.03529412)
        /// </summary>
        public static Color RustyOrange { get; } = new Color(0.8039216f, 0.3490196f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.5882353, 0.3098039)
        /// </summary>
        public static Color PastelOrange { get; } = new Color(1f, 0.5882353f, 0.3098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7529412, 0.3058824, 0.003921569)
        /// </summary>
        public static Color BurntOrange { get; } = new Color(0.7529412f, 0.3058824f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7764706, 0.3176471, 0.007843138)
        /// </summary>
        public static Color DarkOrange { get; } = new Color(0.7764706f, 0.3176471f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6627451, 0.3372549, 0.1176471)
        /// </summary>
        public static Color Sienna { get; } = new Color(0.6627451f, 0.3372549f, 0.1176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9411765, 0.5137255, 0.227451)
        /// </summary>
        public static Color DustyOrange { get; } = new Color(0.9411765f, 0.5137255f, 0.227451f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6901961, 0.4862745)
        /// </summary>
        public static Color Peach { get; } = new Color(1f, 0.6901961f, 0.4862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6901961, 0.3058824, 0.05882353)
        /// </summary>
        public static Color BurntSienna { get; } = new Color(0.6901961f, 0.3058824f, 0.05882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6352941, 0.3960784, 0.2431373)
        /// </summary>
        public static Color Earth { get; } = new Color(0.6352941f, 0.3960784f, 0.2431373f);

        /// <summary>
        /// A formatted XKCD survey colour (0.254902, 0.09803922, 0)
        /// </summary>
        public static Color ChocolateBrown { get; } = new Color(0.254902f, 0.09803922f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.5529412, 0.2862745)
        /// </summary>
        public static Color Orangeish { get; } = new Color(0.9921569f, 0.5529412f, 0.2862745f);

        /// <summary>
        /// A formatted XKCD survey colour (0.627451, 0.2705882, 0.05490196)
        /// </summary>
        public static Color BurntUmber { get; } = new Color(0.627451f, 0.2705882f, 0.05490196f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.3568628, 0)
        /// </summary>
        public static Color BrightOrange { get; } = new Color(1f, 0.3568628f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7568628, 0.2901961, 0.03529412)
        /// </summary>
        public static Color BrickOrange { get; } = new Color(0.7568628f, 0.2901961f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8627451, 0.3019608, 0.003921569)
        /// </summary>
        public static Color DeepOrange { get; } = new Color(0.8627451f, 0.3019608f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5450981, 0.1921569, 0.01176471)
        /// </summary>
        public static Color RustBrown { get; } = new Color(0.5450981f, 0.1921569f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.454902, 0.1568628, 0.007843138)
        /// </summary>
        public static Color Chestnut { get; } = new Color(0.454902f, 0.1568628f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6313726, 0.2235294, 0.01960784)
        /// </summary>
        public static Color Russet { get; } = new Color(0.6313726f, 0.2235294f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6588235, 0.2352941, 0.03529412)
        /// </summary>
        public static Color Rust { get; } = new Color(0.6588235f, 0.2352941f, 0.03529412f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6117647, 0.427451, 0.3411765)
        /// </summary>
        public static Color Brownish { get; } = new Color(0.6117647f, 0.427451f, 0.3411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5921569, 0.5411765, 0.5176471)
        /// </summary>
        public static Color WarmGrey { get; } = new Color(0.5921569f, 0.5411765f, 0.5176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.509804, 0.2901961)
        /// </summary>
        public static Color Orangish { get; } = new Color(0.9882353f, 0.509804f, 0.2901961f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7411765, 0.4235294, 0.282353)
        /// </summary>
        public static Color Adobe { get; } = new Color(0.7411765f, 0.4235294f, 0.282353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6039216, 0.1882353, 0.003921569)
        /// </summary>
        public static Color Auburn { get; } = new Color(0.6039216f, 0.1882353f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7882353, 0.3921569, 0.2313726)
        /// </summary>
        public static Color TerraCotta { get; } = new Color(0.7882353f, 0.3921569f, 0.2313726f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8509804, 0.6078432, 0.509804)
        /// </summary>
        public static Color PinkishTan { get; } = new Color(0.8509804f, 0.6078432f, 0.509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.2941177, 0.01176471)
        /// </summary>
        public static Color BloodOrange { get; } = new Color(0.9960784f, 0.2941177f, 0.01176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4980392, 0.1686275, 0.03921569)
        /// </summary>
        public static Color ReddishBrown { get; } = new Color(0.4980392f, 0.1686275f, 0.03921569f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7960784, 0.4078431, 0.2627451)
        /// </summary>
        public static Color Terracota { get; } = new Color(0.7960784f, 0.4078431f, 0.2627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7921569, 0.4, 0.254902)
        /// </summary>
        public static Color Terracotta { get; } = new Color(0.7921569f, 0.4f, 0.254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.572549, 0.1686275, 0.01960784)
        /// </summary>
        public static Color BrownRed { get; } = new Color(0.572549f, 0.1686275f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8705882, 0.4941176, 0.3647059)
        /// </summary>
        public static Color DarkPeach { get; } = new Color(0.8705882f, 0.4941176f, 0.3647059f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7137255, 0.4156863, 0.3137255)
        /// </summary>
        public static Color Clay { get; } = new Color(0.7137255f, 0.4156863f, 0.3137255f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6941177, 0.6039216)
        /// </summary>
        public static Color PaleSalmon { get; } = new Color(1f, 0.6941177f, 0.6039216f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.2352941, 0.02352941)
        /// </summary>
        public static Color RedOrange { get; } = new Color(0.9921569f, 0.2352941f, 0.02352941f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.2588235, 0.05882353)
        /// </summary>
        public static Color Orangered { get; } = new Color(0.9960784f, 0.2588235f, 0.05882353f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6941177, 0.4470588, 0.3803922)
        /// </summary>
        public static Color PinkishBrown { get; } = new Color(0.6941177f, 0.4470588f, 0.3803922f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.4470588, 0.2980392)
        /// </summary>
        public static Color PinkishOrange { get; } = new Color(1f, 0.4470588f, 0.2980392f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6666667, 0.1529412, 0.01568628)
        /// </summary>
        public static Color RustRed { get; } = new Color(0.6666667f, 0.1529412f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6862745, 0.1843137, 0.05098039)
        /// </summary>
        public static Color RustyRed { get; } = new Color(0.6862745f, 0.1843137f, 0.05098039f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.4705882, 0.3333333)
        /// </summary>
        public static Color Melon { get; } = new Color(1f, 0.4705882f, 0.3333333f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9960784, 0.6627451, 0.5764706)
        /// </summary>
        public static Color LightSalmon { get; } = new Color(0.9960784f, 0.6627451f, 0.5764706f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5450981, 0.1803922, 0.08627451)
        /// </summary>
        public static Color RedBrown { get; } = new Color(0.5450981f, 0.1803922f, 0.08627451f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9568627, 0.2117647, 0.01960784)
        /// </summary>
        public static Color OrangishRed { get; } = new Color(0.9568627f, 0.2117647f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.972549, 0.282353, 0.1098039)
        /// </summary>
        public static Color ReddishOrange { get; } = new Color(0.972549f, 0.282353f, 0.1098039f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6235294, 0.1372549, 0.01960784)
        /// </summary>
        public static Color BurntRed { get; } = new Color(0.6235294f, 0.1372549f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9254902, 0.1764706, 0.003921569)
        /// </summary>
        public static Color TomatoRed { get; } = new Color(0.9254902f, 0.1764706f, 0.003921569f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.4352941, 0.3215686)
        /// </summary>
        public static Color OrangePink { get; } = new Color(1f, 0.4352941f, 0.3215686f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9568627, 0.1960784, 0.04705882)
        /// </summary>
        public static Color Vermillion { get; } = new Color(0.9568627f, 0.1960784f, 0.04705882f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9490196, 0.6196079, 0.5568628)
        /// </summary>
        public static Color Blush { get; } = new Color(0.9490196f, 0.6196079f, 0.5568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.254902, 0.1176471)
        /// </summary>
        public static Color OrangeRed { get; } = new Color(0.9921569f, 0.254902f, 0.1176471f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6196079, 0.2117647, 0.1372549)
        /// </summary>
        public static Color BrownishRed { get; } = new Color(0.6196079f, 0.2117647f, 0.1372549f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.9568627, 0.9490196)
        /// </summary>
        public static Color VeryLightPink { get; } = new Color(1f, 0.9568627f, 0.9490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.627451, 0.2117647, 0.1372549)
        /// </summary>
        public static Color Brick { get; } = new Color(0.627451f, 0.2117647f, 0.1372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9803922, 0.2588235, 0.1411765)
        /// </summary>
        public static Color OrangeyRed { get; } = new Color(0.9803922f, 0.2588235f, 0.1411765f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.6039216, 0.5411765)
        /// </summary>
        public static Color PeachyPink { get; } = new Color(1f, 0.6039216f, 0.5411765f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9372549, 0.2509804, 0.1490196)
        /// </summary>
        public static Color Tomato { get; } = new Color(0.9372549f, 0.2509804f, 0.1490196f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5607843, 0.07843138, 0.007843138)
        /// </summary>
        public static Color BrickRed { get; } = new Color(0.5607843f, 0.07843138f, 0.007843138f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6, 0.4588235, 0.4392157)
        /// </summary>
        public static Color ReddishGrey { get; } = new Color(0.6f, 0.4588235f, 0.4392157f);

        /// <summary>
        /// A formatted XKCD survey colour (0.4313726, 0.0627451, 0.01960784)
        /// </summary>
        public static Color ReddyBrown { get; } = new Color(0.4313726f, 0.0627451f, 0.01960784f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.6745098, 0.6627451)
        /// </summary>
        public static Color PinkishGrey { get; } = new Color(0.7843137f, 0.6745098f, 0.6627451f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 0.4745098, 0.4235294)
        /// </summary>
        public static Color Salmon { get; } = new Color(1f, 0.4745098f, 0.4235294f);

        /// <summary>
        /// A formatted XKCD survey colour (0.5215687, 0.05490196, 0.01568628)
        /// </summary>
        public static Color IndianRed { get; } = new Color(0.5215687f, 0.05490196f, 0.01568628f);

        /// <summary>
        /// A formatted XKCD survey colour (0.1137255, 0.007843138, 0)
        /// </summary>
        public static Color VeryDarkBrown { get; } = new Color(0.1137255f, 0.007843138f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7607843, 0.4941176, 0.4745098)
        /// </summary>
        public static Color BrownishPink { get; } = new Color(0.7607843f, 0.4941176f, 0.4745098f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7843137, 0.3529412, 0.3254902)
        /// </summary>
        public static Color DarkSalmon { get; } = new Color(0.7843137f, 0.3529412f, 0.3254902f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9882353, 0.3529412, 0.3137255)
        /// </summary>
        public static Color Coral { get; } = new Color(0.9882353f, 0.3529412f, 0.3137255f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8509804, 0.3294118, 0.3019608)
        /// </summary>
        public static Color PaleRed { get; } = new Color(0.8509804f, 0.3294118f, 0.3019608f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8117647, 0.3215686, 0.3058824)
        /// </summary>
        public static Color DarkCoral { get; } = new Color(0.8117647f, 0.3215686f, 0.3058824f);

        /// <summary>
        /// A formatted XKCD survey colour (0.254902, 0.007843138, 0)
        /// </summary>
        public static Color DeepBrown { get; } = new Color(0.254902f, 0.007843138f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.9921569, 0.3490196, 0.3372549)
        /// </summary>
        public static Color Grapefruit { get; } = new Color(0.9921569f, 0.3490196f, 0.3372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.7686275, 0.2588235, 0.2509804)
        /// </summary>
        public static Color Reddish { get; } = new Color(0.7686275f, 0.2588235f, 0.2509804f);

        /// <summary>
        /// A formatted XKCD survey colour (0.8588235, 0.345098, 0.3372549)
        /// </summary>
        public static Color PastelRed { get; } = new Color(0.8588235f, 0.345098f, 0.3372549f);

        /// <summary>
        /// A formatted XKCD survey colour (0.2901961, 0.003921569, 0)
        /// </summary>
        public static Color Mahogany { get; } = new Color(0.2901961f, 0.003921569f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0.6039216, 0.007843138, 0)
        /// </summary>
        public static Color DeepRed { get; } = new Color(0.6039216f, 0.007843138f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (0, 0, 0)
        /// </summary>
        public static Color Black { get; } = new Color(0f, 0f, 0f);

        /// <summary>
        /// A formatted XKCD survey colour (1, 1, 1)
        /// </summary>
        public static Color White { get; } = new Color(1f, 1f, 1f);
        #endregion

        #region Map
        /// <summary>
        /// A name to colour parsing dictionary
        /// </summary>
        private static readonly Dictionary<string, Color> stringToColour = new Dictionary<string, Color>(949, StringComparer.InvariantCultureIgnoreCase)
        {
            ["Red"] = Red,
            ["DarkRed"] = DarkRed,
            ["DriedBlood"] = DriedBlood,
            ["DullRed"] = DullRed,
            ["SalmonPink"] = SalmonPink,
            ["FireEngineRed"] = FireEngineRed,
            ["Blood"] = Blood,
            ["CoralPink"] = CoralPink,
            ["BloodRed"] = BloodRed,
            ["LightRed"] = LightRed,
            ["DarkishRed"] = DarkishRed,
            ["FadedRed"] = FadedRed,
            ["BrightRed"] = BrightRed,
            ["DustyRed"] = DustyRed,
            ["DirtyPink"] = DirtyPink,
            ["PaleRose"] = PaleRose,
            ["BlushPink"] = BlushPink,
            ["DustyRose"] = DustyRose,
            ["LightRose"] = LightRose,
            ["Watermelon"] = Watermelon,
            ["Crimson"] = Crimson,
            ["PurpleBrown"] = PurpleBrown,
            ["GreyishPink"] = GreyishPink,
            ["PurplishBrown"] = PurplishBrown,
            ["Strawberry"] = Strawberry,
            ["Scarlet"] = Scarlet,
            ["Carmine"] = Carmine,
            ["LightishRed"] = LightishRed,
            ["DarkMaroon"] = DarkMaroon,
            ["DustyPink"] = DustyPink,
            ["DuskyRose"] = DuskyRose,
            ["OldRose"] = OldRose,
            ["PinkyRed"] = PinkyRed,
            ["CherryRed"] = CherryRed,
            ["LightMaroon"] = LightMaroon,
            ["Carnation"] = Carnation,
            ["OldPink"] = OldPink,
            ["RosePink"] = RosePink,
            ["UglyPink"] = UglyPink,
            ["Rose"] = Rose,
            ["Pinkish"] = Pinkish,
            ["ReddishPink"] = ReddishPink,
            ["DarkRose"] = DarkRose,
            ["NeonRed"] = NeonRed,
            ["RedPink"] = RedPink,
            ["DuskyPink"] = DuskyPink,
            ["SoftPink"] = SoftPink,
            ["GreyPink"] = GreyPink,
            ["Claret"] = Claret,
            ["BrownishPurple"] = BrownishPurple,
            ["FadedPink"] = FadedPink,
            ["LipstickRed"] = LipstickRed,
            ["Cherry"] = Cherry,
            ["PinkishRed"] = PinkishRed,
            ["DeepRose"] = DeepRose,
            ["Rosa"] = Rosa,
            ["LightBurgundy"] = LightBurgundy,
            ["Rouge"] = Rouge,
            ["PigPink"] = PigPink,
            ["Mauve"] = Mauve,
            ["WarmPink"] = WarmPink,
            ["WineRed"] = WineRed,
            ["RosyPink"] = RosyPink,
            ["PalePink"] = PalePink,
            ["MutedPink"] = MutedPink,
            ["PastelPink"] = PastelPink,
            ["Lipstick"] = Lipstick,
            ["DullPink"] = DullPink,
            ["DarkPink"] = DarkPink,
            ["LightPink"] = LightPink,
            ["Pinky"] = Pinky,
            ["PinkRed"] = PinkRed,
            ["RoseRed"] = RoseRed,
            ["CarnationPink"] = CarnationPink,
            ["LightMauve"] = LightMauve,
            ["BabyPink"] = BabyPink,
            ["Maroon"] = Maroon,
            ["Ruby"] = Ruby,
            ["Bordeaux"] = Bordeaux,
            ["Burgundy"] = Burgundy,
            ["MediumPink"] = MediumPink,
            ["Cranberry"] = Cranberry,
            ["RedWine"] = RedWine,
            ["DarkishPink"] = DarkishPink,
            ["DarkMauve"] = DarkMauve,
            ["PowderPink"] = PowderPink,
            ["PurplishRed"] = PurplishRed,
            ["Cerise"] = Cerise,
            ["Raspberry"] = Raspberry,
            ["Berry"] = Berry,
            ["PurpleRed"] = PurpleRed,
            ["BubbleGumPink"] = BubbleGumPink,
            ["DarkHotPink"] = DarkHotPink,
            ["DeepPink"] = DeepPink,
            ["Wine"] = Wine,
            ["Merlot"] = Merlot,
            ["Bubblegum"] = Bubblegum,
            ["Mulberry"] = Mulberry,
            ["Pink"] = Pink,
            ["VioletRed"] = VioletRed,
            ["BarbiePink"] = BarbiePink,
            ["RedPurple"] = RedPurple,
            ["StrongPink"] = StrongPink,
            ["ReddishPurple"] = ReddishPurple,
            ["DarkFuchsia"] = DarkFuchsia,
            ["HotPink"] = HotPink,
            ["ElectricPink"] = ElectricPink,
            ["DeepMagenta"] = DeepMagenta,
            ["DarkMagenta"] = DarkMagenta,
            ["BubblegumPink"] = BubblegumPink,
            ["NeonPink"] = NeonPink,
            ["Magenta"] = Magenta,
            ["PaleMagenta"] = PaleMagenta,
            ["LightPlum"] = LightPlum,
            ["ShockingPink"] = ShockingPink,
            ["RedViolet"] = RedViolet,
            ["DirtyPurple"] = DirtyPurple,
            ["Velvet"] = Velvet,
            ["Plum"] = Plum,
            ["DarkPlum"] = DarkPlum,
            ["BrightPink"] = BrightPink,
            ["DuskyPurple"] = DuskyPurple,
            ["PurplishPink"] = PurplishPink,
            ["RichPurple"] = RichPurple,
            ["Bruise"] = Bruise,
            ["Grape"] = Grape,
            ["HotMagenta"] = HotMagenta,
            ["Aubergine"] = Aubergine,
            ["Purpleish"] = Purpleish,
            ["GrapePurple"] = GrapePurple,
            ["PurpleishPink"] = PurpleishPink,
            ["CandyPink"] = CandyPink,
            ["DullPurple"] = DullPurple,
            ["Purplish"] = Purplish,
            ["PurpleyPink"] = PurpleyPink,
            ["DustyLavender"] = DustyLavender,
            ["BrightMagenta"] = BrightMagenta,
            ["Fuchsia"] = Fuchsia,
            ["PinkyPurple"] = PinkyPurple,
            ["PurplyPink"] = PurplyPink,
            ["LavenderPink"] = LavenderPink,
            ["Eggplant"] = Eggplant,
            ["LightEggplant"] = LightEggplant,
            ["WarmPurple"] = WarmPurple,
            ["BarneyPurple"] = BarneyPurple,
            ["PurplePink"] = PurplePink,
            ["Orchid"] = Orchid,
            ["PaleMauve"] = PaleMauve,
            ["PurpleGrey"] = PurpleGrey,
            ["UglyPurple"] = UglyPurple,
            ["Pink_Purple"] = Pink_Purple,
            ["EggplantPurple"] = EggplantPurple,
            ["DarkishPurple"] = DarkishPurple,
            ["LightMagenta"] = LightMagenta,
            ["DeepViolet"] = DeepViolet,
            ["PinkPurple"] = PinkPurple,
            ["PurpleyGrey"] = PurpleyGrey,
            ["VioletPink"] = VioletPink,
            ["PinkishPurple"] = PinkishPurple,
            ["PlumPurple"] = PlumPurple,
            ["Purple_Pink"] = Purple_Pink,
            ["MediumPurple"] = MediumPurple,
            ["Barney"] = Barney,
            ["DustyPurple"] = DustyPurple,
            ["VeryLightPurple"] = VeryLightPurple,
            ["DeepPurple"] = DeepPurple,
            ["MutedPurple"] = MutedPurple,
            ["DarkPurple"] = DarkPurple,
            ["DarkLilac"] = DarkLilac,
            ["Heliotrope"] = Heliotrope,
            ["HotPurple"] = HotPurple,
            ["DarkViolet"] = DarkViolet,
            ["FadedPurple"] = FadedPurple,
            ["VeryDarkPurple"] = VeryDarkPurple,
            ["Heather"] = Heather,
            ["SoftPurple"] = SoftPurple,
            ["PurplishGrey"] = PurplishGrey,
            ["VibrantPurple"] = VibrantPurple,
            ["Purply"] = Purply,
            ["Purple"] = Purple,
            ["LightLavendar"] = LightLavendar,
            ["BrightPurple"] = BrightPurple,
            ["MidnightPurple"] = MidnightPurple,
            ["NeonPurple"] = NeonPurple,
            ["GreyishPurple"] = GreyishPurple,
            ["RoyalPurple"] = RoyalPurple,
            ["BrightLilac"] = BrightLilac,
            ["GreyPurple"] = GreyPurple,
            ["LightLilac"] = LightLilac,
            ["BrightViolet"] = BrightViolet,
            ["PaleLavender"] = PaleLavender,
            ["BrightLavender"] = BrightLavender,
            ["Violet"] = Violet,
            ["Wisteria"] = Wisteria,
            ["Amethyst"] = Amethyst,
            ["ElectricPurple"] = ElectricPurple,
            ["DarkLavender"] = DarkLavender,
            ["VividPurple"] = VividPurple,
            ["PalePurple"] = PalePurple,
            ["LightPurple"] = LightPurple,
            ["LightishPurple"] = LightishPurple,
            ["EasterPurple"] = EasterPurple,
            ["DeepLavender"] = DeepLavender,
            ["BabyPurple"] = BabyPurple,
            ["DeepLilac"] = DeepLilac,
            ["LightUrple"] = LightUrple,
            ["Lavender"] = Lavender,
            ["LighterPurple"] = LighterPurple,
            ["Liliac"] = Liliac,
            ["Lilac"] = Lilac,
            ["PaleLilac"] = PaleLilac,
            ["LightViolet"] = LightViolet,
            ["LightLavender"] = LightLavender,
            ["PastelPurple"] = PastelPurple,
            ["Indigo"] = Indigo,
            ["PaleViolet"] = PaleViolet,
            ["BlueViolet"] = BlueViolet,
            ["VioletBlue"] = VioletBlue,
            ["Blue_Purple"] = Blue_Purple,
            ["PurplyBlue"] = PurplyBlue,
            ["Purpley"] = Purpley,
            ["Purple_Blue"] = Purple_Blue,
            ["BluishPurple"] = BluishPurple,
            ["Burple"] = Burple,
            ["PurplishBlue"] = PurplishBlue,
            ["DarkIndigo"] = DarkIndigo,
            ["PurpleBlue"] = PurpleBlue,
            ["BluePurple"] = BluePurple,
            ["BlueyPurple"] = BlueyPurple,
            ["PurpleyBlue"] = PurpleyBlue,
            ["IndigoBlue"] = IndigoBlue,
            ["Blurple"] = Blurple,
            ["PurpleishBlue"] = PurpleishBlue,
            ["Ultramarine"] = Ultramarine,
            ["BlueWithAHintOfPurple"] = BlueWithAHintOfPurple,
            ["LightIndigo"] = LightIndigo,
            ["Periwinkle"] = Periwinkle,
            ["Iris"] = Iris,
            ["UltramarineBlue"] = UltramarineBlue,
            ["DarkPeriwinkle"] = DarkPeriwinkle,
            ["Blueberry"] = Blueberry,
            ["LightRoyalBlue"] = LightRoyalBlue,
            ["Midnight"] = Midnight,
            ["MidnightBlue"] = MidnightBlue,
            ["Perrywinkle"] = Perrywinkle,
            ["LavenderBlue"] = LavenderBlue,
            ["StrongBlue"] = StrongBlue,
            ["DeepBlue"] = DeepBlue,
            ["PrimaryBlue"] = PrimaryBlue,
            ["NightBlue"] = NightBlue,
            ["RoyalBlue"] = RoyalBlue,
            ["PaleGrey"] = PaleGrey,
            ["PureBlue"] = PureBlue,
            ["VeryDarkBlue"] = VeryDarkBlue,
            ["DarkBlue"] = DarkBlue,
            ["DarkRoyalBlue"] = DarkRoyalBlue,
            ["Darkblue"] = Darkblue,
            ["CobaltBlue"] = CobaltBlue,
            ["DarkNavyBlue"] = DarkNavyBlue,
            ["Twilight"] = Twilight,
            ["TrueBlue"] = TrueBlue,
            ["DarkNavy"] = DarkNavy,
            ["Royal"] = Royal,
            ["WarmBlue"] = WarmBlue,
            ["LightPeriwinkle"] = LightPeriwinkle,
            ["PeriwinkleBlue"] = PeriwinkleBlue,
            ["RichBlue"] = RichBlue,
            ["Cornflower"] = Cornflower,
            ["VividBlue"] = VividBlue,
            ["Dusk"] = Dusk,
            ["Sapphire"] = Sapphire,
            ["BlueBlue"] = BlueBlue,
            ["VibrantBlue"] = VibrantBlue,
            ["CornflowerBlue"] = CornflowerBlue,
            ["NavyBlue"] = NavyBlue,
            ["SoftBlue"] = SoftBlue,
            ["Blue"] = Blue,
            ["ElectricBlue"] = ElectricBlue,
            ["Azul"] = Azul,
            ["DuskyBlue"] = DuskyBlue,
            ["PastelBlue"] = PastelBlue,
            ["LightishBlue"] = LightishBlue,
            ["Navy"] = Navy,
            ["DodgerBlue"] = DodgerBlue,
            ["DenimBlue"] = DenimBlue,
            ["Cobalt"] = Cobalt,
            ["FrenchBlue"] = FrenchBlue,
            ["ClearBlue"] = ClearBlue,
            ["CarolinaBlue"] = CarolinaBlue,
            ["BrightBlue"] = BrightBlue,
            ["Dark"] = Dark,
            ["LightBlueGrey"] = LightBlueGrey,
            ["PowderBlue"] = PowderBlue,
            ["DuskBlue"] = DuskBlue,
            ["DeepSkyBlue"] = DeepSkyBlue,
            ["CeruleanBlue"] = CeruleanBlue,
            ["FadedBlue"] = FadedBlue,
            ["Marine"] = Marine,
            ["DarkSkyBlue"] = DarkSkyBlue,
            ["MediumBlue"] = MediumBlue,
            ["WindowsBlue"] = WindowsBlue,
            ["MidBlue"] = MidBlue,
            ["LightNavyBlue"] = LightNavyBlue,
            ["CloudyBlue"] = CloudyBlue,
            ["BabyBlue"] = BabyBlue,
            ["Denim"] = Denim,
            ["DarkishBlue"] = DarkishBlue,
            ["TwilightBlue"] = TwilightBlue,
            ["FlatBlue"] = FlatBlue,
            ["SkyBlue"] = SkyBlue,
            ["Blue_Grey"] = Blue_Grey,
            ["OffBlue"] = OffBlue,
            ["MarineBlue"] = MarineBlue,
            ["Bluish"] = Bluish,
            ["CadetBlue"] = CadetBlue,
            ["Steel"] = Steel,
            ["DullBlue"] = DullBlue,
            ["DustyBlue"] = DustyBlue,
            ["LightNavy"] = LightNavy,
            ["CoolBlue"] = CoolBlue,
            ["SlateBlue"] = SlateBlue,
            ["MutedBlue"] = MutedBlue,
            ["SteelBlue"] = SteelBlue,
            ["GreyishBlue"] = GreyishBlue,
            ["GreyBlue"] = GreyBlue,
            ["LightGreyBlue"] = LightGreyBlue,
            ["StormyBlue"] = StormyBlue,
            ["MetallicBlue"] = MetallicBlue,
            ["LightBlue"] = LightBlue,
            ["PrussianBlue"] = PrussianBlue,
            ["DarkGreyBlue"] = DarkGreyBlue,
            ["BlueyGrey"] = BlueyGrey,
            ["Sky"] = Sky,
            ["DarkSlateBlue"] = DarkSlateBlue,
            ["Grey_Blue"] = Grey_Blue,
            ["UglyBlue"] = UglyBlue,
            ["SlateGrey"] = SlateGrey,
            ["Slate"] = Slate,
            ["DarkBlueGrey"] = DarkBlueGrey,
            ["BlueGrey"] = BlueGrey,
            ["Azure"] = Azure,
            ["Lightblue"] = Lightblue,
            ["Cerulean"] = Cerulean,
            ["WaterBlue"] = WaterBlue,
            ["DeepSeaBlue"] = DeepSeaBlue,
            ["BattleshipGrey"] = BattleshipGrey,
            ["BluishGrey"] = BluishGrey,
            ["NiceBlue"] = NiceBlue,
            ["Bluegrey"] = Bluegrey,
            ["Greyblue"] = Greyblue,
            ["PeacockBlue"] = PeacockBlue,
            ["SteelGrey"] = SteelGrey,
            ["DirtyBlue"] = DirtyBlue,
            ["OceanBlue"] = OceanBlue,
            ["Gunmetal"] = Gunmetal,
            ["SeaBlue"] = SeaBlue,
            ["BrightSkyBlue"] = BrightSkyBlue,
            ["CoolGrey"] = CoolGrey,
            ["CharcoalGrey"] = CharcoalGrey,
            ["Ocean"] = Ocean,
            ["NeonBlue"] = NeonBlue,
            ["TealBlue"] = TealBlue,
            ["PaleSkyBlue"] = PaleSkyBlue,
            ["RobinEggBlue"] = RobinEggBlue,
            ["RobinSEgg"] = RobinSEgg,
            ["Petrol"] = Petrol,
            ["RobinSEggBlue"] = RobinSEggBlue,
            ["TurquoiseBlue"] = TurquoiseBlue,
            ["AquaBlue"] = AquaBlue,
            ["DeepAqua"] = DeepAqua,
            ["DeepTeal"] = DeepTeal,
            ["LightSkyBlue"] = LightSkyBlue,
            ["BrightLightBlue"] = BrightLightBlue,
            ["DarkAqua"] = DarkAqua,
            ["DarkCyan"] = DarkCyan,
            ["DarkTeal"] = DarkTeal,
            ["DeepTurquoise"] = DeepTurquoise,
            ["BrightCyan"] = BrightCyan,
            ["Cyan"] = Cyan,
            ["AlmostBlack"] = AlmostBlack,
            ["PaleBlue"] = PaleBlue,
            ["ReallyLightBlue"] = ReallyLightBlue,
            ["VeryLightBlue"] = VeryLightBlue,
            ["DarkGrey"] = DarkGrey,
            ["Bluegreen"] = Bluegreen,
            ["DarkAquamarine"] = DarkAquamarine,
            ["BrightTurquoise"] = BrightTurquoise,
            ["DarkTurquoise"] = DarkTurquoise,
            ["VeryPaleBlue"] = VeryPaleBlue,
            ["IceBlue"] = IceBlue,
            ["GreenishBlue"] = GreenishBlue,
            ["LightCyan"] = LightCyan,
            ["BrightAqua"] = BrightAqua,
            ["PaleCyan"] = PaleCyan,
            ["Topaz"] = Topaz,
            ["Sea"] = Sea,
            ["LightLightBlue"] = LightLightBlue,
            ["Teal"] = Teal,
            ["Blue_Green"] = Blue_Green,
            ["DarkBlueGreen"] = DarkBlueGreen,
            ["Turquoise"] = Turquoise,
            ["Ice"] = Ice,
            ["DuckEggBlue"] = DuckEggBlue,
            ["Tealish"] = Tealish,
            ["EggshellBlue"] = EggshellBlue,
            ["Aqua"] = Aqua,
            ["BlueGreen"] = BlueGreen,
            ["DustyTeal"] = DustyTeal,
            ["DarkGreenBlue"] = DarkGreenBlue,
            ["Aquamarine"] = Aquamarine,
            ["TiffanyBlue"] = TiffanyBlue,
            ["BrightTeal"] = BrightTeal,
            ["GreenBlue"] = GreenBlue,
            ["DullTeal"] = DullTeal,
            ["AquaMarine"] = AquaMarine,
            ["Charcoal"] = Charcoal,
            ["GreenyBlue"] = GreenyBlue,
            ["Green_Blue"] = Green_Blue,
            ["GreyTeal"] = GreyTeal,
            ["PaleAqua"] = PaleAqua,
            ["GreenishTurquoise"] = GreenishTurquoise,
            ["SeafoamBlue"] = SeafoamBlue,
            ["GreyishTeal"] = GreyishTeal,
            ["LightAqua"] = LightAqua,
            ["BluishGreen"] = BluishGreen,
            ["GreenishCyan"] = GreenishCyan,
            ["LightTurquoise"] = LightTurquoise,
            ["PaleTeal"] = PaleTeal,
            ["Greenblue"] = Greenblue,
            ["DarkSeaGreen"] = DarkSeaGreen,
            ["BrightSeaGreen"] = BrightSeaGreen,
            ["Viridian"] = Viridian,
            ["GreenTeal"] = GreenTeal,
            ["Jade"] = Jade,
            ["AquaGreen"] = AquaGreen,
            ["DarkSeafoam"] = DarkSeafoam,
            ["TealGreen"] = TealGreen,
            ["OceanGreen"] = OceanGreen,
            ["LightAquamarine"] = LightAquamarine,
            ["LightTeal"] = LightTeal,
            ["BlueyGreen"] = BlueyGreen,
            ["GreenishTeal"] = GreenishTeal,
            ["Evergreen"] = Evergreen,
            ["PaleTurquoise"] = PaleTurquoise,
            ["TurquoiseGreen"] = TurquoiseGreen,
            ["LightGreenishBlue"] = LightGreenishBlue,
            ["Spruce"] = Spruce,
            ["Seaweed"] = Seaweed,
            ["DarkMintGreen"] = DarkMintGreen,
            ["JungleGreen"] = JungleGreen,
            ["Silver"] = Silver,
            ["DarkSeafoamGreen"] = DarkSeafoamGreen,
            ["TealishGreen"] = TealishGreen,
            ["MintyGreen"] = MintyGreen,
            ["AlgaeGreen"] = AlgaeGreen,
            ["JadeGreen"] = JadeGreen,
            ["Wintergreen"] = Wintergreen,
            ["SeaGreen"] = SeaGreen,
            ["LightGreenBlue"] = LightGreenBlue,
            ["Emerald"] = Emerald,
            ["SeaweedGreen"] = SeaweedGreen,
            ["LightBlueGreen"] = LightBlueGreen,
            ["Shamrock"] = Shamrock,
            ["Greenish"] = Greenish,
            ["Spearmint"] = Spearmint,
            ["WeirdGreen"] = WeirdGreen,
            ["ShamrockGreen"] = ShamrockGreen,
            ["SeafoamGreen"] = SeafoamGreen,
            ["KelleyGreen"] = KelleyGreen,
            ["Seafoam"] = Seafoam,
            ["LightBluishGreen"] = LightBluishGreen,
            ["CoolGreen"] = CoolGreen,
            ["DarkMint"] = DarkMint,
            ["LightSeafoam"] = LightSeafoam,
            ["Tea"] = Tea,
            ["PineGreen"] = PineGreen,
            ["IrishGreen"] = IrishGreen,
            ["KellyGreen"] = KellyGreen,
            ["LightSeaGreen"] = LightSeaGreen,
            ["FoamGreen"] = FoamGreen,
            ["Algae"] = Algae,
            ["HospitalGreen"] = HospitalGreen,
            ["SlateGreen"] = SlateGreen,
            ["EmeraldGreen"] = EmeraldGreen,
            ["BrightLightGreen"] = BrightLightGreen,
            ["Pine"] = Pine,
            ["Mint"] = Mint,
            ["DarkishGreen"] = DarkishGreen,
            ["LightSeafoamGreen"] = LightSeafoamGreen,
            ["BabyGreen"] = BabyGreen,
            ["DeepGreen"] = DeepGreen,
            ["MintGreen"] = MintGreen,
            ["LightMintGreen"] = LightMintGreen,
            ["MediumGreen"] = MediumGreen,
            ["BritishRacingGreen"] = BritishRacingGreen,
            ["ForestGreen"] = ForestGreen,
            ["DarkForestGreen"] = DarkForestGreen,
            ["SoftGreen"] = SoftGreen,
            ["LightMint"] = LightMint,
            ["LightForestGreen"] = LightForestGreen,
            ["LightBrightGreen"] = LightBrightGreen,
            ["Lightgreen"] = Lightgreen,
            ["LightNeonGreen"] = LightNeonGreen,
            ["Green"] = Green,
            ["Darkgreen"] = Darkgreen,
            ["BoringGreen"] = BoringGreen,
            ["BrightGreen"] = BrightGreen,
            ["HotGreen"] = HotGreen,
            ["BottleGreen"] = BottleGreen,
            ["DarkPastelGreen"] = DarkPastelGreen,
            ["FluorescentGreen"] = FluorescentGreen,
            ["NeonGreen"] = NeonGreen,
            ["LightishGreen"] = LightishGreen,
            ["VibrantGreen"] = VibrantGreen,
            ["RacingGreen"] = RacingGreen,
            ["Forest"] = Forest,
            ["TrueGreen"] = TrueGreen,
            ["FluroGreen"] = FluroGreen,
            ["HunterGreen"] = HunterGreen,
            ["DustyGreen"] = DustyGreen,
            ["DarkGreen"] = DarkGreen,
            ["RadioactiveGreen"] = RadioactiveGreen,
            ["DarkSage"] = DarkSage,
            ["VeryDarkGreen"] = VeryDarkGreen,
            ["ElectricGreen"] = ElectricGreen,
            ["HighlighterGreen"] = HighlighterGreen,
            ["MidGreen"] = MidGreen,
            ["Celadon"] = Celadon,
            ["GreenyGrey"] = GreenyGrey,
            ["EasterGreen"] = EasterGreen,
            ["FadedGreen"] = FadedGreen,
            ["LighterGreen"] = LighterGreen,
            ["GreyishGreen"] = GreyishGreen,
            ["GreyGreen"] = GreyGreen,
            ["VividGreen"] = VividGreen,
            ["LightPastelGreen"] = LightPastelGreen,
            ["MutedGreen"] = MutedGreen,
            ["TreeGreen"] = TreeGreen,
            ["LeafyGreen"] = LeafyGreen,
            ["PoisonGreen"] = PoisonGreen,
            ["FreshGreen"] = FreshGreen,
            ["PastelGreen"] = PastelGreen,
            ["Fern"] = Fern,
            ["LightGreen"] = LightGreen,
            ["FernGreen"] = FernGreen,
            ["GreenGrey"] = GreenGrey,
            ["ForrestGreen"] = ForrestGreen,
            ["PaleLightGreen"] = PaleLightGreen,
            ["PaleGreen"] = PaleGreen,
            ["LightSage"] = LightSage,
            ["Grey"] = Grey,
            ["Grey_Green"] = Grey_Green,
            ["DullGreen"] = DullGreen,
            ["SageGreen"] = SageGreen,
            ["GreenishGrey"] = GreenishGrey,
            ["WashedOutGreen"] = WashedOutGreen,
            ["VeryPaleGreen"] = VeryPaleGreen,
            ["OffGreen"] = OffGreen,
            ["VeryLightGreen"] = VeryLightGreen,
            ["LightLightGreen"] = LightLightGreen,
            ["ToxicGreen"] = ToxicGreen,
            ["TeaGreen"] = TeaGreen,
            ["GreenApple"] = GreenApple,
            ["LightGrey"] = LightGrey,
            ["MediumGrey"] = MediumGrey,
            ["Sage"] = Sage,
            ["Lichen"] = Lichen,
            ["LightGreyGreen"] = LightGreyGreen,
            ["Apple"] = Apple,
            ["FlatGreen"] = FlatGreen,
            ["GrassGreen"] = GrassGreen,
            ["TurtleGreen"] = TurtleGreen,
            ["LightGrassGreen"] = LightGrassGreen,
            ["Grass"] = Grass,
            ["BrightLimeGreen"] = BrightLimeGreen,
            ["Asparagus"] = Asparagus,
            ["GrassyGreen"] = GrassyGreen,
            ["SpringGreen"] = SpringGreen,
            ["DarkGrassGreen"] = DarkGrassGreen,
            ["Celery"] = Celery,
            ["NastyGreen"] = NastyGreen,
            ["LawnGreen"] = LawnGreen,
            ["KeyLime"] = KeyLime,
            ["FrogGreen"] = FrogGreen,
            ["LightLime"] = LightLime,
            ["Moss"] = Moss,
            ["KiwiGreen"] = KiwiGreen,
            ["Pistachio"] = Pistachio,
            ["AppleGreen"] = AppleGreen,
            ["LightYellowishGreen"] = LightYellowishGreen,
            ["PaleLimeGreen"] = PaleLimeGreen,
            ["DrabGreen"] = DrabGreen,
            ["KermitGreen"] = KermitGreen,
            ["Leaf"] = Leaf,
            ["Kiwi"] = Kiwi,
            ["BrightLime"] = BrightLime,
            ["LimeGreen"] = LimeGreen,
            ["LightPeaGreen"] = LightPeaGreen,
            ["LeafGreen"] = LeafGreen,
            ["MossGreen"] = MossGreen,
            ["LightLimeGreen"] = LightLimeGreen,
            ["PaleLime"] = PaleLime,
            ["AcidGreen"] = AcidGreen,
            ["Lime"] = Lime,
            ["NavyGreen"] = NavyGreen,
            ["LightMossGreen"] = LightMossGreen,
            ["MossyGreen"] = MossyGreen,
            ["SapGreen"] = SapGreen,
            ["LightYellowGreen"] = LightYellowGreen,
            ["BrightYellowGreen"] = BrightYellowGreen,
            ["PaleOliveGreen"] = PaleOliveGreen,
            ["MilitaryGreen"] = MilitaryGreen,
            ["Swamp"] = Swamp,
            ["ElectricLime"] = ElectricLime,
            ["DarkLimeGreen"] = DarkLimeGreen,
            ["LemonGreen"] = LemonGreen,
            ["CamoGreen"] = CamoGreen,
            ["LemonLime"] = LemonLime,
            ["Pear"] = Pear,
            ["DirtyGreen"] = DirtyGreen,
            ["YellowGreen"] = YellowGreen,
            ["CamouflageGreen"] = CamouflageGreen,
            ["DarkLime"] = DarkLime,
            ["Yellow_Green"] = Yellow_Green,
            ["TanGreen"] = TanGreen,
            ["LightOliveGreen"] = LightOliveGreen,
            ["Yellowgreen"] = Yellowgreen,
            ["Avocado"] = Avocado,
            ["KhakiGreen"] = KhakiGreen,
            ["SlimeGreen"] = SlimeGreen,
            ["ArmyGreen"] = ArmyGreen,
            ["PaleOlive"] = PaleOlive,
            ["AvocadoGreen"] = AvocadoGreen,
            ["GreenYellow"] = GreenYellow,
            ["YellowyGreen"] = YellowyGreen,
            ["Camo"] = Camo,
            ["Chartreuse"] = Chartreuse,
            ["DarkOliveGreen"] = DarkOliveGreen,
            ["MuddyGreen"] = MuddyGreen,
            ["YellowishGreen"] = YellowishGreen,
            ["IckyGreen"] = IckyGreen,
            ["LightOlive"] = LightOlive,
            ["Booger"] = Booger,
            ["GreenyYellow"] = GreenyYellow,
            ["DarkYellowGreen"] = DarkYellowGreen,
            ["LimeYellow"] = LimeYellow,
            ["SicklyGreen"] = SicklyGreen,
            ["SickGreen"] = SickGreen,
            ["UglyGreen"] = UglyGreen,
            ["GreenishYellow"] = GreenishYellow,
            ["NeonYellow"] = NeonYellow,
            ["PeaGreen"] = PeaGreen,
            ["SnotGreen"] = SnotGreen,
            ["GreenishTan"] = GreenishTan,
            ["GrossGreen"] = GrossGreen,
            ["Pea"] = Pea,
            ["BoogerGreen"] = BoogerGreen,
            ["BrightOlive"] = BrightOlive,
            ["OliveGreen"] = OliveGreen,
            ["VomitGreen"] = VomitGreen,
            ["LightKhaki"] = LightKhaki,
            ["BarfGreen"] = BarfGreen,
            ["MurkyGreen"] = MurkyGreen,
            ["SwampGreen"] = SwampGreen,
            ["Green_Yellow"] = Green_Yellow,
            ["PeaSoupGreen"] = PeaSoupGreen,
            ["PukeGreen"] = PukeGreen,
            ["BabyShitGreen"] = BabyShitGreen,
            ["DarkOlive"] = DarkOlive,
            ["SicklyYellow"] = SicklyYellow,
            ["PoopGreen"] = PoopGreen,
            ["OliveDrab"] = OliveDrab,
            ["GreenishBeige"] = GreenishBeige,
            ["Snot"] = Snot,
            ["ShitGreen"] = ShitGreen,
            ["Bile"] = Bile,
            ["BabyPukeGreen"] = BabyPukeGreen,
            ["MustardGreen"] = MustardGreen,
            ["Olive"] = Olive,
            ["BabyPoopGreen"] = BabyPoopGreen,
            ["MudGreen"] = MudGreen,
            ["PeaSoup"] = PeaSoup,
            ["BrownishGreen"] = BrownishGreen,
            ["BananaYellow"] = BananaYellow,
            ["Ecru"] = Ecru,
            ["Drab"] = Drab,
            ["Vomit"] = Vomit,
            ["Canary"] = Canary,
            ["Lemon"] = Lemon,
            ["OffYellow"] = OffYellow,
            ["LemonYellow"] = LemonYellow,
            ["FadedYellow"] = FadedYellow,
            ["Puke"] = Puke,
            ["Yellow"] = Yellow,
            ["Banana"] = Banana,
            ["Butter"] = Butter,
            ["YellowishTan"] = YellowishTan,
            ["PaleYellow"] = PaleYellow,
            ["Creme"] = Creme,
            ["Cream"] = Cream,
            ["Ivory"] = Ivory,
            ["Eggshell"] = Eggshell,
            ["OffWhite"] = OffWhite,
            ["CanaryYellow"] = CanaryYellow,
            ["PastelYellow"] = PastelYellow,
            ["LightYellow"] = LightYellow,
            ["BrightYellow"] = BrightYellow,
            ["SunshineYellow"] = SunshineYellow,
            ["LightBeige"] = LightBeige,
            ["ButterYellow"] = ButterYellow,
            ["Custard"] = Custard,
            ["PukeYellow"] = PukeYellow,
            ["Parchment"] = Parchment,
            ["SunnyYellow"] = SunnyYellow,
            ["BrownyGreen"] = BrownyGreen,
            ["VomitYellow"] = VomitYellow,
            ["PissYellow"] = PissYellow,
            ["DirtyYellow"] = DirtyYellow,
            ["Manilla"] = Manilla,
            ["BrownGreen"] = BrownGreen,
            ["Straw"] = Straw,
            ["EggShell"] = EggShell,
            ["Khaki"] = Khaki,
            ["OliveYellow"] = OliveYellow,
            ["UglyYellow"] = UglyYellow,
            ["GreenBrown"] = GreenBrown,
            ["Yellowish"] = Yellowish,
            ["Buff"] = Buff,
            ["GreenyBrown"] = GreenyBrown,
            ["GreenishBrown"] = GreenishBrown,
            ["UglyBrown"] = UglyBrown,
            ["Cement"] = Cement,
            ["MuddyYellow"] = MuddyYellow,
            ["MustardYellow"] = MustardYellow,
            ["SandyYellow"] = SandyYellow,
            ["DarkCream"] = DarkCream,
            ["DullYellow"] = DullYellow,
            ["Dandelion"] = Dandelion,
            ["BrownishYellow"] = BrownishYellow,
            ["Pale"] = Pale,
            ["Mustard"] = Mustard,
            ["SunYellow"] = SunYellow,
            ["SunflowerYellow"] = SunflowerYellow,
            ["DarkYellow"] = DarkYellow,
            ["BrownYellow"] = BrownYellow,
            ["BabyPoop"] = BabyPoop,
            ["BabyPoo"] = BabyPoo,
            ["LightTan"] = LightTan,
            ["OliveBrown"] = OliveBrown,
            ["DarkKhaki"] = DarkKhaki,
            ["Diarrhea"] = Diarrhea,
            ["SandYellow"] = SandYellow,
            ["BabyShitBrown"] = BabyShitBrown,
            ["Beige"] = Beige,
            ["Gold"] = Gold,
            ["DarkMustard"] = DarkMustard,
            ["YellowBrown"] = YellowBrown,
            ["YellowTan"] = YellowTan,
            ["Sandy"] = Sandy,
            ["Bland"] = Bland,
            ["DarkGold"] = DarkGold,
            ["Poo"] = Poo,
            ["Ocher"] = Ocher,
            ["Hazel"] = Hazel,
            ["PukeBrown"] = PukeBrown,
            ["LightGold"] = LightGold,
            ["BurntYellow"] = BurntYellow,
            ["Stone"] = Stone,
            ["Greyish"] = Greyish,
            ["PaleGold"] = PaleGold,
            ["YellowishBrown"] = YellowishBrown,
            ["YellowyBrown"] = YellowyBrown,
            ["Ocre"] = Ocre,
            ["Sand"] = Sand,
            ["Golden"] = Golden,
            ["Maize"] = Maize,
            ["LightMustard"] = LightMustard,
            ["Goldenrod"] = Goldenrod,
            ["YellowOchre"] = YellowOchre,
            ["Mud"] = Mud,
            ["Wheat"] = Wheat,
            ["GoldenYellow"] = GoldenYellow,
            ["BrownGrey"] = BrownGrey,
            ["Marigold"] = Marigold,
            ["Sunflower"] = Sunflower,
            ["MuddyBrown"] = MuddyBrown,
            ["Shit"] = Shit,
            ["Ochre"] = Ochre,
            ["GoldenRod"] = GoldenRod,
            ["Poop"] = Poop,
            ["PoopBrown"] = PoopBrown,
            ["MustardBrown"] = MustardBrown,
            ["Bronze"] = Bronze,
            ["Desert"] = Desert,
            ["OrangeyYellow"] = OrangeyYellow,
            ["ShitBrown"] = ShitBrown,
            ["YellowOrange"] = YellowOrange,
            ["SandyBrown"] = SandyBrown,
            ["PooBrown"] = PooBrown,
            ["Amber"] = Amber,
            ["Putty"] = Putty,
            ["Saffron"] = Saffron,
            ["Tan"] = Tan,
            ["GoldenBrown"] = GoldenBrown,
            ["DarkSand"] = DarkSand,
            ["PalePeach"] = PalePeach,
            ["MacaroniAndCheese"] = MacaroniAndCheese,
            ["Sandstone"] = Sandstone,
            ["MudBrown"] = MudBrown,
            ["Squash"] = Squash,
            ["OrangeYellow"] = OrangeYellow,
            ["DarkBeige"] = DarkBeige,
            ["GreyBrown"] = GreyBrown,
            ["YellowishOrange"] = YellowishOrange,
            ["SandBrown"] = SandBrown,
            ["Camel"] = Camel,
            ["VeryLightBrown"] = VeryLightBrown,
            ["RawSienna"] = RawSienna,
            ["Toupe"] = Toupe,
            ["Dust"] = Dust,
            ["GreyishBrown"] = GreyishBrown,
            ["Fawn"] = Fawn,
            ["BrownishGrey"] = BrownishGrey,
            ["Caramel"] = Caramel,
            ["DarkTan"] = DarkTan,
            ["DirtBrown"] = DirtBrown,
            ["Dirt"] = Dirt,
            ["Taupe"] = Taupe,
            ["Coffee"] = Coffee,
            ["DullBrown"] = DullBrown,
            ["Butterscotch"] = Butterscotch,
            ["Mango"] = Mango,
            ["MediumBrown"] = MediumBrown,
            ["DirtyOrange"] = DirtyOrange,
            ["Tangerine"] = Tangerine,
            ["BrownOrange"] = BrownOrange,
            ["Umber"] = Umber,
            ["Brown"] = Brown,
            ["LightOrange"] = LightOrange,
            ["RawUmber"] = RawUmber,
            ["OrangeyBrown"] = OrangeyBrown,
            ["Leather"] = Leather,
            ["DarkTaupe"] = DarkTaupe,
            ["Puce"] = Puce,
            ["LightBrown"] = LightBrown,
            ["Pumpkin"] = Pumpkin,
            ["OrangeBrown"] = OrangeBrown,
            ["TanBrown"] = TanBrown,
            ["OrangishBrown"] = OrangishBrown,
            ["BrownyOrange"] = BrownyOrange,
            ["PaleBrown"] = PaleBrown,
            ["DarkBrown"] = DarkBrown,
            ["WarmBrown"] = WarmBrown,
            ["BrownishOrange"] = BrownishOrange,
            ["LightPeach"] = LightPeach,
            ["MilkChocolate"] = MilkChocolate,
            ["Mocha"] = Mocha,
            ["PumpkinOrange"] = PumpkinOrange,
            ["PaleOrange"] = PaleOrange,
            ["DullOrange"] = DullOrange,
            ["Sepia"] = Sepia,
            ["Apricot"] = Apricot,
            ["Orange"] = Orange,
            ["ClayBrown"] = ClayBrown,
            ["Chocolate"] = Chocolate,
            ["Mushroom"] = Mushroom,
            ["Cinnamon"] = Cinnamon,
            ["BurntSiena"] = BurntSiena,
            ["FadedOrange"] = FadedOrange,
            ["Copper"] = Copper,
            ["Cocoa"] = Cocoa,
            ["RustOrange"] = RustOrange,
            ["RustyOrange"] = RustyOrange,
            ["PastelOrange"] = PastelOrange,
            ["BurntOrange"] = BurntOrange,
            ["DarkOrange"] = DarkOrange,
            ["Sienna"] = Sienna,
            ["DustyOrange"] = DustyOrange,
            ["Peach"] = Peach,
            ["BurntSienna"] = BurntSienna,
            ["Earth"] = Earth,
            ["ChocolateBrown"] = ChocolateBrown,
            ["Orangeish"] = Orangeish,
            ["BurntUmber"] = BurntUmber,
            ["BrightOrange"] = BrightOrange,
            ["BrickOrange"] = BrickOrange,
            ["DeepOrange"] = DeepOrange,
            ["RustBrown"] = RustBrown,
            ["Chestnut"] = Chestnut,
            ["Russet"] = Russet,
            ["Rust"] = Rust,
            ["Brownish"] = Brownish,
            ["WarmGrey"] = WarmGrey,
            ["Orangish"] = Orangish,
            ["Adobe"] = Adobe,
            ["Auburn"] = Auburn,
            ["TerraCotta"] = TerraCotta,
            ["PinkishTan"] = PinkishTan,
            ["BloodOrange"] = BloodOrange,
            ["ReddishBrown"] = ReddishBrown,
            ["Terracota"] = Terracota,
            ["Terracotta"] = Terracotta,
            ["BrownRed"] = BrownRed,
            ["DarkPeach"] = DarkPeach,
            ["Clay"] = Clay,
            ["PaleSalmon"] = PaleSalmon,
            ["RedOrange"] = RedOrange,
            ["Orangered"] = Orangered,
            ["PinkishBrown"] = PinkishBrown,
            ["PinkishOrange"] = PinkishOrange,
            ["RustRed"] = RustRed,
            ["RustyRed"] = RustyRed,
            ["Melon"] = Melon,
            ["LightSalmon"] = LightSalmon,
            ["RedBrown"] = RedBrown,
            ["OrangishRed"] = OrangishRed,
            ["ReddishOrange"] = ReddishOrange,
            ["BurntRed"] = BurntRed,
            ["TomatoRed"] = TomatoRed,
            ["OrangePink"] = OrangePink,
            ["Vermillion"] = Vermillion,
            ["Blush"] = Blush,
            ["OrangeRed"] = OrangeRed,
            ["BrownishRed"] = BrownishRed,
            ["VeryLightPink"] = VeryLightPink,
            ["Brick"] = Brick,
            ["OrangeyRed"] = OrangeyRed,
            ["PeachyPink"] = PeachyPink,
            ["Tomato"] = Tomato,
            ["BrickRed"] = BrickRed,
            ["ReddishGrey"] = ReddishGrey,
            ["ReddyBrown"] = ReddyBrown,
            ["PinkishGrey"] = PinkishGrey,
            ["Salmon"] = Salmon,
            ["IndianRed"] = IndianRed,
            ["VeryDarkBrown"] = VeryDarkBrown,
            ["BrownishPink"] = BrownishPink,
            ["DarkSalmon"] = DarkSalmon,
            ["Coral"] = Coral,
            ["PaleRed"] = PaleRed,
            ["DarkCoral"] = DarkCoral,
            ["DeepBrown"] = DeepBrown,
            ["Grapefruit"] = Grapefruit,
            ["Reddish"] = Reddish,
            ["PastelRed"] = PastelRed,
            ["Mahogany"] = Mahogany,
            ["DeepRed"] = DeepRed,
            ["Black"] = Black,
            ["White"] = White
        };

        /// <summary>
        /// Dummy method, forces the static constructor to run and generate the data
        /// </summary>
        internal static void Init() { }

        /// <summary>
        /// Gets an XKCDColour from it's name
        /// </summary>
        /// <param name="name">Name of the colour to get</param>
        /// <returns>The found colour of the given name</returns>
        public static Color GetColor(string name) => stringToColour[name];

        /// <summary>
        /// Tries and gets an XKCDColour from it's name, and stores it in the out parameter
        /// </summary>
        /// <param name="name">Name of the colour to get</param>
        /// <param name="colour">Color to store the result in</param>
        /// <returns>True if the colour of the given name was found, false otherwise</returns>
        public static bool TryGetColor(string name, out Color colour) => stringToColour.TryGetValue(name, out colour);
        #endregion
    }
}