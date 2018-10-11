using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary>
        /// Gets the default accent brush.
        /// </summary>
        private SolidColorBrush ThemeAccentBrush => (SolidColorBrush)Application.Current.Resources["SystemControlHighlightChromeHighBrush"];

        /// <summary>
        /// Gets the default background brush.
        /// </summary>
        private SolidColorBrush ThemeBackgroundBrush => (SolidColorBrush)Application.Current.Resources["SystemControlBackgroundBaseMediumLowBrush"];

        /// <summary>
        /// Gets the default foreground brush.
        /// </summary>
        private SolidColorBrush ThemeForegroundBrush => (SolidColorBrush)Application.Current.Resources["SystemControlForegroundBaseHighBrush"];

        /// <inheritdoc/>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new RadialGaugeAutomationPeer(this);
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
                if (ThemeAccentBrush is SolidColorBrush highlightBrush)
                {
                    NeedleBrush = highlightBrush;
                    TrailBrush = highlightBrush;
                }

                if (ThemeBackgroundBrush is SolidColorBrush backgroundBrush)
                {
                    ScaleBrush = backgroundBrush;
                    ScaleTickBrush = backgroundBrush;
                }

                if (ThemeForegroundBrush is SolidColorBrush foregroundBrush)
                {
                    TickBrush = foregroundBrush;
                    Foreground = foregroundBrush;
                }
            }
            else
            {
                // Apply User Defined or Default Theme.
                if (_needleBrush == null)
                {
                    ClearValue(NeedleBrushProperty);
                }
                else
                {
                    NeedleBrush = _needleBrush;
                }

                if (_trailBrush == null)
                {
                    ClearValue(TrailBrushProperty);
                }
                else
                {
                    TrailBrush = _trailBrush;
                }

                if (_scaleBrush == null)
                {
                    ClearValue(ScaleBrushProperty);
                }
                else
                {
                    ScaleBrush = _scaleBrush;
                }

                if (_scaleTickBrush == null)
                {
                    ClearValue(ScaleTickBrushProperty);
                }
                else
                {
                    ScaleTickBrush = _scaleTickBrush;
                }

                if (_foreground == null)
                {
                    ClearValue(ForegroundProperty);
                }
                else
                {
                    Foreground = _foreground;
                }

                if (_tickBrush == null)
                {
                    ClearValue(TickBrushProperty);
                }
                else
                {
                    TickBrush = _tickBrush;
                }
            }

            OnScaleChanged(this);
        }


    }
}
