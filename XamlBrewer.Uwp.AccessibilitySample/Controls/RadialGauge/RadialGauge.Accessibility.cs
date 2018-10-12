using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Media;

namespace Microsoft.Toolkit.Uwp.UI.Controls
{
    partial class RadialGauge
    {
        // High-contrast accessibility
        private static readonly AccessibilitySettings ThemeListener = new AccessibilitySettings();
        private SolidColorBrush _needleBrush;
        private Brush _trailBrush;
        private Brush _scaleBrush;
        private SolidColorBrush _scaleTickBrush;
        private SolidColorBrush _tickBrush;
        private Brush _foreground;

        /// <inheritdoc/>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new RadialGaugeAutomationPeer(this);
        }

        private void InitializeHighContrast()
        {
            // Remember local brushes.
            _needleBrush = ReadLocalValue(NeedleBrushProperty) as SolidColorBrush;
            _trailBrush = ReadLocalValue(TrailBrushProperty) as SolidColorBrush;
            _scaleBrush = ReadLocalValue(ScaleBrushProperty) as SolidColorBrush;
            _scaleTickBrush = ReadLocalValue(ScaleTickBrushProperty) as SolidColorBrush;
            _tickBrush = ReadLocalValue(TickBrushProperty) as SolidColorBrush;
            _foreground = ReadLocalValue(ForegroundProperty) as SolidColorBrush;

            // Apply color scheme.
            OnColorsChanged();
        }

        private void ThemeListener_HighContrastChanged(AccessibilitySettings sender, object args)
        {
            OnColorsChanged();
        }

        private void OnColorsChanged()
        {
            if (ThemeListener.HighContrast)
            {
                // Apply High Contrast Theme.
                ClearBrush(_needleBrush, NeedleBrushProperty);
                ClearBrush(_trailBrush, TrailBrushProperty);
                ClearBrush(_scaleBrush, ScaleBrushProperty);
                ClearBrush(_scaleBrush, ScaleTickBrushProperty);
                ClearBrush(_tickBrush, TickBrushProperty);
                ClearBrush(_foreground, ForegroundProperty);
            }
            else
            {
                // Apply User Defined or Default Theme.
                RestoreBrush(_needleBrush, NeedleBrushProperty);
                RestoreBrush(_trailBrush, TrailBrushProperty);
                RestoreBrush(_scaleBrush, ScaleBrushProperty);
                RestoreBrush(_scaleBrush, ScaleTickBrushProperty);
                RestoreBrush(_tickBrush, TickBrushProperty);
                RestoreBrush(_foreground, ForegroundProperty);
            }

            OnScaleChanged(this);
        }

        private void ClearBrush(Brush brush, DependencyProperty prop)
        {
            if (brush != null)
            {
                ClearValue(prop);
            }
        }

        private void RestoreBrush(Brush source, DependencyProperty prop)
        {
            if (source != null)
            {
                SetValue(prop, source);
            }
        }
    }
}
