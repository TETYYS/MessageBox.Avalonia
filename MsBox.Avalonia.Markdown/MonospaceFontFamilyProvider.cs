using Avalonia.Media;

namespace MsBox.Avalonia.Markdown;

public static class MonospaceFontFamilyProvider
{
    private static readonly string[] PreferredFamilies = [
        "Courier New",
        "monospace",
        "Menlo",
        "DejaVu Sans Mono",
        "Liberation Mono",
        "Cascadia Code",
        "Cascadia Mono",
        "Monaco",
        "Consolas",
        "Fira Code",
        "Noto Sans Mono",
        "Droid Sans Mono",
        "Inconsolata"
    ];

    public static FontFamily Value { get; } = Resolve();

    private static FontFamily Resolve()
    {
        var systemFonts = FontManager.Current.SystemFonts.ToArray();

        foreach (var preferredFamily in PreferredFamilies) {
            var exactMatch = systemFonts.FirstOrDefault(font =>
                font.Name.Equals(preferredFamily, StringComparison.OrdinalIgnoreCase));

            if (exactMatch is not null)
                return exactMatch;
        }

        return FontFamily.Default;
    }
}
