using System.Collections.Generic;
using System;
using Discord;

namespace �nteraction.Utilities {
	public static partial class ColorUtilities {

	}

	// Constants
	public static partial class ColorUtilities {
		public const uint MaxRawValue = 16_777_215;	// The highest value allowed for a RGB color
		private static Color _default = new Color( 0.50f, 0.50f, 0.50f );
		public static Color Default => _default;

		private static readonly Dictionary<ColorCodes, Color> DefaultColors;

		static ColorUtilities() {
			DefaultColors = new Dictionary<ColorCodes, Color>();
		}

		private static void SetDefaultColor(ColorCodes code, double r, double g, double b) {
			DefaultColors.TryAdd(code, new Color((float) r, (float) g, (float) b));
		}

		private static void SetDefaultColor(ColorCodes code, byte r, byte g, byte b) {
			DefaultColors.TryAdd(code, new Color(r, g, b));
		}

		private static void SetDefaultColor(ColorCodes code, uint number)
			=> DefaultColors.TryAdd(code, new Color(number));


		public static Color CreateColor(uint rawValue) {
			rawValue = Math.Min(rawValue, MaxRawValue);
			return new Color(rawValue);
		}

		public static Color GetDefaultColor(ColorCodes code) {
			return DefaultColors.GetValueOrDefault(code, Default);
		}

		public static Dictionary<TKey, Color> GenerateColorDict<TKey>(Dictionary<TKey, ColorCodes> input) {
			var res = new Dictionary<TKey, Color>();

			foreach(var pair in input) {
				res.TryAdd(pair.Key, GetDefaultColor(pair.Value));
			}

			return res;
		}
	}

	public enum ColorCodes : uint {
		Default = 0x7F7F7F,
		Black_Absolute = 0x000000,
		Black = 0x0C0C0C,
		Grey_Dark = 0x3F3F3F,
		Grey = 0x7F7F7F,
		Grey_Light = 0xD3D3D3,
		White = 0xF2F2F2,
		White_Absolute = 0xFFFFFF,
		Red_Light = 0xFF3333,
		Red = 0xFF0000,
		Red_Dark = 0x8C0000,
		Green_Light = 0x8EED8E,
		Green = 0x007F00,
		Green_Dark = 0x006300,
		Blue_Light = 0xADD8E5,
		Blue = 0x0000FF,
		Blue_Dark = 0x00008C,
		Yellow_Light = 0xFF0000,
		Yellow = 0xFFCC00,
		Yellow_Dark = 0xFFFFCC,
		Orange_Light = 0xD8A366,
		Orange = 0xFFA500,
		Orange_Dark = 0xFF8C00,
		Purple_Light = 0x9370DB,
		Purple = 0xA021EF,
		Purple_Dark = 0x663399,
		Pink_Light = 0x000000,
		Pink = 0xFFBFCC,
		Pink_Dark = 0xE8547F,
		Cyan_Light = 0xE0FFFF,
		Cyan = 0x00FFFF,
		Cyan_Dark = 0x008C8C,
		Magenta_Light = 0xFF77FF,
		Magenta = 0xFF00FF,
		Magenta_Dark = 0x8C008C,
		Brown_Light = 0xAF7F51,
		Brown = 0xA52828,
		Brown_Dark = 0x5B3F33,
		Violet_Light = 0x7A5199,
		Violet = 0xED82ED,
		Violet_Dark = 0x9300D3,
		Turquoise_Light = 0xAFE2DD,
		Turquoise = 0x30D6C6,
		Turquoise_Dark = 0x00CED1,
		Mustard_Light = 0xEDDD60,
		Mustard = 0xFFDB59,
		Mustard_Dark = 0x7C7C3F,
		Ivory_Light = 0xFFF7C9,
		Ivory = 0xFFFFEF,
		Ivory_Dark = 0xF2E58E,
		Gold_Light = 0xF2E5AA,
		Gold = 0xFFD600,
		Gold_Dark = 0xEDBC1C,
		Silver_Light = 0xE0E0E0,
		Silver = 0xBFBFBF,
		Silver_Dark = 0xAFAFAF,
		Silver_Crayola = 0xC9C0BB,
		Silver_Pink = 0xC4AEAD,
		Silver_Sand = 0xBFC1C2,
		Silver_Chalice = 0xACACAC,
		Silver_Roman = 0x838996,
		Silver_Old = 0x848482,
		Silver_Sonic = 0x757575,
		Bronze = 0xCD7F32,
		Bronze_BlastOff = 0xA57164,
		Bronze_Antique = 0x665D1E,
		Lime = 0x00FF00,
		Teal = 0x007F7F,
		Aquamarine = 0x7FFFD3,
		Aqua = 0x00FFFF,
		Beige = 0xF4F4DB,
		Crimson = 0xDB143D,
		Coral = 0xFF7F4F,
		Deep_Sky_Blue = 0x00BFFF,
		Dodger_Blue = 0x1E90FF,
		Firebrick = 0xB22222,
		Fuchsia = 0xFF00FF,
		Indigo = 0x4B0082,
		Light_Sky_Blue = 0x87CEFA,
		Maroon = 0xB03060,
	}

	public static class ColorExtention {
		public static Color ToColor(this ColorCodes code) => ((uint) code).ToColor();
		public static Color ToColor(this uint val) => new Color(val);
	}
}