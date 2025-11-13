using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace InvestigateZoomLevel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currentAutoZoom = 1.0;
        private double currentMouseWheelZoom = 1.0;
        private const double ZoomIncrement = 0.1; // 10% increment per wheel tick
        private const double MinZoom = 0.1;
        private const double MaxZoom = 5.0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeSampleContent();
        }

        private void InitializeSampleContent()
        {
            // Add sample content to all RichTextBoxes to demonstrate zoom
            AddSampleContent(RtbNative);
            AddSampleContent(RtbTransform);
            AddSampleContent(RtbViewbox);
            AddSampleContent(RtbAutoZoom);
            AddSampleContent(RtbDropdown);
            AddSampleContent(RtbMouseWheel);
        }

        private void AddSampleContent(RichTextBox rtb)
        {
            FlowDocument doc = new FlowDocument();

            // Title
            Paragraph title = new Paragraph(new Run("Rich Text Editor - Zoom Test Document"));
            title.FontSize = 24;
            title.FontWeight = FontWeights.Bold;
            title.Foreground = Brushes.DarkBlue;
            doc.Blocks.Add(title);

            // Introduction
            Paragraph intro = new Paragraph(new Run(
                "This document contains text at various font sizes to help you test the zoom functionality. " +
                "Try different zoom levels to see how each implementation handles the scaling."));
            intro.FontSize = 12;
            doc.Blocks.Add(intro);

            // Various sized text
            Paragraph largeText = new Paragraph(new Run("Large Text (20pt) - Easy to read"));
            largeText.FontSize = 20;
            largeText.FontWeight = FontWeights.SemiBold;
            doc.Blocks.Add(largeText);

            Paragraph mediumText = new Paragraph(new Run("Medium Text (14pt) - Standard reading size"));
            mediumText.FontSize = 14;
            doc.Blocks.Add(mediumText);

            Paragraph normalText = new Paragraph(new Run("Normal Text (12pt) - Common default size"));
            normalText.FontSize = 12;
            doc.Blocks.Add(normalText);

            Paragraph smallText = new Paragraph(new Run("Small Text (10pt) - Getting harder to read"));
            smallText.FontSize = 10;
            doc.Blocks.Add(smallText);

            Paragraph tinyText = new Paragraph(new Run("Tiny Text (8pt) - Very difficult to read without zoom"));
            tinyText.FontSize = 8;
            tinyText.Foreground = Brushes.DarkRed;
            doc.Blocks.Add(tinyText);

            // Mixed formatting paragraph
            Paragraph mixed = new Paragraph();
            mixed.Inlines.Add(new Run("Mixed formatting: ") { FontSize = 12, FontWeight = FontWeights.Bold });
            mixed.Inlines.Add(new Run("Bold ") { FontSize = 14, FontWeight = FontWeights.Bold });
            mixed.Inlines.Add(new Run("Italic ") { FontSize = 12, FontStyle = FontStyles.Italic });
            mixed.Inlines.Add(new Run("Underline ") { FontSize = 12, TextDecorations = TextDecorations.Underline });
            mixed.Inlines.Add(new Run("Colored") { FontSize = 12, Foreground = Brushes.Green });
            doc.Blocks.Add(mixed);

            // List
            List list = new List();
            list.MarkerStyle = TextMarkerStyle.Disc;
            list.ListItems.Add(new ListItem(new Paragraph(new Run("List item with 12pt font")) { FontSize = 12 }));
            list.ListItems.Add(new ListItem(new Paragraph(new Run("List item with 10pt font")) { FontSize = 10 }));
            list.ListItems.Add(new ListItem(new Paragraph(new Run("List item with 8pt font - smallest")) { FontSize = 8 }));
            doc.Blocks.Add(list);

            // Instructions
            Paragraph instructions = new Paragraph(new Run(
                "\nInstructions:\n" +
                "• Try editing this text to see how zoom affects text entry\n" +
                "• Adjust zoom levels using the controls above\n" +
                "• Notice how different implementations handle the zoom differently\n" +
                "• The Auto-Zoom tab will analyze the smallest font (8pt) and scale accordingly"));
            instructions.FontSize = 11;
            instructions.Foreground = Brushes.DarkSlateGray;
            doc.Blocks.Add(instructions);

            rtb.Document = doc;
        }

        #region Tab 1: Native Zoom Property

        private void ZoomNative_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                double zoom = Convert.ToDouble(btn.Tag);
                ApplyNativeZoom(zoom);
            }
        }

        private void SliderNativeZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RtbNative != null && TxtNativeZoom != null)
            {
                ApplyNativeZoom(e.NewValue);
            }
        }

        private void ApplyNativeZoom(double zoom)
        {
            // WPF doesn't have a native Zoom property, so we use LayoutTransform
            // This is the most straightforward approach in WPF
            RtbNative.LayoutTransform = new ScaleTransform(zoom, zoom);
            TxtNativeZoom.Text = $"{(int)(zoom * 100)}%";
            SliderNativeZoom.Value = zoom;
        }

        #endregion

        #region Tab 2: ScaleTransform

        private void ZoomTransform_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                double zoom = Convert.ToDouble(btn.Tag);
                ApplyTransformZoom(zoom);
            }
        }

        private void SliderTransformZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ScaleTransformRtb != null && TxtTransformZoom != null)
            {
                ApplyTransformZoom(e.NewValue);
            }
        }

        private void ApplyTransformZoom(double zoom)
        {
            ScaleTransformRtb.ScaleX = zoom;
            ScaleTransformRtb.ScaleY = zoom;
            TxtTransformZoom.Text = $"{(int)(zoom * 100)}%";
            SliderTransformZoom.Value = zoom;
        }

        #endregion

        #region Tab 3: ViewBox

        private void ZoomViewbox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                double zoom = Convert.ToDouble(btn.Tag);
                ApplyViewboxZoom(zoom);
            }
        }

        private void SliderViewboxZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ViewboxContainer != null && TxtViewboxZoom != null)
            {
                ApplyViewboxZoom(e.NewValue);
            }
        }

        private void ApplyViewboxZoom(double zoom)
        {
            ViewboxContainer.Width = 800 * zoom;
            ViewboxContainer.Height = 400 * zoom;
            TxtViewboxZoom.Text = $"{(int)(zoom * 100)}%";
            SliderViewboxZoom.Value = zoom;
        }

        #endregion

        #region Tab 4: Auto-Zoom

        private void AutoZoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse target font size
                if (!double.TryParse(TxtTargetFontSize.Text, out double targetFontSize) || targetFontSize <= 0)
                {
                    MessageBox.Show("Please enter a valid positive number for target font size.", 
                        "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Find smallest font in the document
                double smallestFont = FindSmallestFontSize(RtbAutoZoom.Document);
                
                if (smallestFont == double.MaxValue)
                {
                    MessageBox.Show("No text found in the document.", 
                        "No Content", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Calculate required zoom factor
                double zoomFactor = targetFontSize / smallestFont;
                
                // Clamp zoom to reasonable range
                zoomFactor = Math.Max(0.1, Math.Min(zoomFactor, 10.0));

                // Apply zoom using LayoutTransform
                currentAutoZoom = zoomFactor;
                RtbAutoZoom.LayoutTransform = new ScaleTransform(zoomFactor, zoomFactor);
                
                // Update UI
                TxtAutoZoom.Text = $"{(int)(zoomFactor * 100)}%";
                TxtSmallestFont.Text = $"(Smallest: {smallestFont:F1}pt → {(smallestFont * zoomFactor):F1}pt)";

                MessageBox.Show(
                    $"Auto-zoom applied!\n\n" +
                    $"Smallest font found: {smallestFont:F1}pt\n" +
                    $"Target font size: {targetFontSize:F1}pt\n" +
                    $"Zoom factor: {(int)(zoomFactor * 100)}%\n" +
                    $"New smallest font: {(smallestFont * zoomFactor):F1}pt",
                    "Auto-Zoom Complete",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during auto-zoom: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AutoZoomReset_Click(object sender, RoutedEventArgs e)
        {
            currentAutoZoom = 1.0;
            RtbAutoZoom.LayoutTransform = new ScaleTransform(1.0, 1.0);
            TxtAutoZoom.Text = "100%";
            TxtSmallestFont.Text = "";
        }

        private double FindSmallestFontSize(FlowDocument document)
        {
            double smallest = double.MaxValue;

            foreach (Block block in document.Blocks)
            {
                smallest = Math.Min(smallest, FindSmallestInBlock(block));
            }

            return smallest;
        }

        private double FindSmallestInBlock(Block block)
        {
            double smallest = double.MaxValue;

            if (block is Paragraph paragraph)
            {
                smallest = Math.Min(smallest, GetEffectiveFontSize(paragraph));
                
                foreach (Inline inline in paragraph.Inlines)
                {
                    smallest = Math.Min(smallest, FindSmallestInInline(inline));
                }
            }
            else if (block is List list)
            {
                foreach (ListItem item in list.ListItems)
                {
                    foreach (Block itemBlock in item.Blocks)
                    {
                        smallest = Math.Min(smallest, FindSmallestInBlock(itemBlock));
                    }
                }
            }
            else if (block is Section section)
            {
                foreach (Block sectionBlock in section.Blocks)
                {
                    smallest = Math.Min(smallest, FindSmallestInBlock(sectionBlock));
                }
            }

            return smallest;
        }

        private double FindSmallestInInline(Inline inline)
        {
            double smallest = GetEffectiveFontSize(inline);

            if (inline is Span span)
            {
                foreach (Inline child in span.Inlines)
                {
                    smallest = Math.Min(smallest, FindSmallestInInline(child));
                }
            }

            return smallest;
        }

        private double GetEffectiveFontSize(TextElement element)
        {
            double fontSize = element.FontSize;
            
            // If FontSize is not explicitly set, it will be NaN or inherited
            if (double.IsNaN(fontSize) || fontSize == 0)
            {
                // Default font size in WPF is typically 12
                fontSize = 12.0;
            }

            return fontSize;
        }

        #endregion

        #region Tab 5: Dropdown (Google Docs Style)

        private void CmbZoomDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbZoomDropdown.SelectedItem is ComboBoxItem item && item.Tag != null && RtbDropdown != null)
            {
                double zoom = Convert.ToDouble(item.Tag);
                RtbDropdown.LayoutTransform = new ScaleTransform(zoom, zoom);
            }
        }

        #endregion

        #region Tab 6: Ctrl + Mouse Wheel

        private void RtbMouseWheel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Check if Ctrl key is pressed
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                // Prevent default scrolling behavior
                e.Handled = true;

                // Calculate new zoom level
                // Mouse wheel delta is typically 120 per notch
                double zoomChange = (e.Delta > 0 ? ZoomIncrement : -ZoomIncrement);
                double newZoom = currentMouseWheelZoom + zoomChange;

                // Clamp zoom to min/max range
                newZoom = Math.Max(MinZoom, Math.Min(newZoom, MaxZoom));

                // Apply zoom
                ApplyMouseWheelZoom(newZoom);
            }
            // If Ctrl is not pressed, allow normal scrolling (don't set e.Handled)
        }

        private void ApplyMouseWheelZoom(double zoom)
        {
            currentMouseWheelZoom = zoom;
            RtbMouseWheel.LayoutTransform = new ScaleTransform(zoom, zoom);
            TxtMouseWheelZoom.Text = $"{(int)(zoom * 100)}%";
        }

        private void MouseWheelZoomReset_Click(object sender, RoutedEventArgs e)
        {
            ApplyMouseWheelZoom(1.0);
        }

        #endregion
    }
}
