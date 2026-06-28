using MudBlazor;

namespace ECommerceSystemBl.Theme
{
    public static class AppTheme
    {
        public static MudTheme CommerceTheme = new()
        {
            PaletteLight = new PaletteLight
            {
                Primary = "#4F46E5",
                Secondary = "#64748B",
                Background = "#F8FAFC",
                Surface = "#FFFFFF",
                AppbarBackground = "#FFFFFF",
                AppbarText = "#1E293B",
                TextPrimary = "#1E293B",
                TextSecondary = "#64748B",
                Divider = "#E2E8F0"
            },

            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "12px"
            }
        };
    }
}