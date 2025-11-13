# RichTextBox Zoom Level Implementations

A comprehensive WPF application demonstrating **6 different approaches** to implementing zoom functionality in a Rich Text Editor.

## 🎯 Overview

This project showcases multiple zoom implementation strategies for WPF RichTextBox controls, each with its own advantages and limitations. Perfect for developers looking to add zoom capabilities to their text editors.

## ✨ Features

### 6 Zoom Implementation Tabs:

1. **LayoutTransform (Simple)**
   - Direct ScaleTransform application
   - Built-in ScrollViewer handles scrolling automatically
   - Simplest WPF approach

2. **ScaleTransform with ScrollViewer**
   - Custom scroll container approach
   - Smooth scaling with no value limits
   - Clean visual scaling

3. **ViewBox Zoom**
   - Container-based scaling approach
   - Dynamic width/height adjustment
   - Good for consistent scaling

4. **Auto-Zoom (Smart)** ⭐
   - Automatically analyzes document to find smallest font size
   - Calculates zoom to ensure minimum readable size
   - User sets target minimum font size
   - Perfect for accessibility!

5. **Dropdown (Google Docs Style)**
   - Familiar ComboBox dropdown UI
   - Preset zoom levels (50%, 75%, 90%, 100%, 125%, 150%, 200%)
   - Clean, compact interface

6. **Ctrl + Mouse Wheel** 🖱️
   - Most intuitive zoom method
   - Hold Ctrl and scroll to zoom in/out
   - Smooth, incremental zoom control
   - Familiar from browsers and IDEs

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.8
- Windows OS

### Building the Project

```bash
# Clone the repository
git clone https://github.com/p-liviu-stefan/RichTextBox_ZoomLevel.git
cd RichTextBox_ZoomLevel

# Open the solution
InvestigateZoomLevel.sln

# Build in Visual Studio or via command line
msbuild InvestigateZoomLevel\InvestigateZoomLevel.csproj /p:Configuration=Release
```

### Running the Application

1. Build the project
2. Run `InvestigateZoomLevel.exe` from the `bin/Debug` or `bin/Release` folder
3. Switch between tabs to compare different zoom implementations
4. Each tab includes sample content with various font sizes (8pt to 24pt)

## 📖 Usage Examples

### Auto-Zoom (Tab 4)
```
1. Navigate to "4. Auto-Zoom (Smart)" tab
2. Enter target minimum font size (e.g., 12)
3. Click "Auto-Zoom" button
4. The editor will automatically zoom so the smallest text meets your target size
```

### Ctrl + Mouse Wheel (Tab 6)
```
1. Navigate to "6. Ctrl + Mouse Wheel" tab
2. Click in the editor to focus it
3. Hold Ctrl and scroll mouse wheel up → Zoom In
4. Hold Ctrl and scroll mouse wheel down → Zoom Out
5. Release Ctrl to scroll normally
```

## 🎨 UI Features

- **Color-coded limitation boxes** - Each tab clearly shows advantages (✓), limitations (✗), and usage instructions (📝)
- **Live zoom indicators** - Real-time zoom percentage display
- **Professional styling** - Modern, clean interface with styled controls
- **Rich sample content** - Pre-loaded text with multiple font sizes, formatting, and lists

## 🔧 Technical Implementation

### Key Components
- **WPF RichTextBox** - Core text editing control
- **FlowDocument** - Document structure for rich text
- **ScaleTransform** - Primary zoom mechanism
- **LayoutTransform** - Transform application method
- **PreviewMouseWheel** - Ctrl+Wheel event handling

### Code Structure
```
InvestigateZoomLevel/
├── MainWindow.xaml       # UI layout with 6 tab implementations
├── MainWindow.xaml.cs    # Event handlers and zoom logic
├── App.xaml              # Application resources
└── Properties/           # Assembly info and settings
```

## 📝 Implementation Details

Each zoom approach uses different WPF techniques:

- **Tabs 1, 4, 5, 6**: `LayoutTransform` with `ScaleTransform`
- **Tab 2**: `LayoutTransform` inside custom `ScrollViewer`
- **Tab 3**: `ViewBox` with dynamic sizing
- **Tab 4**: Document analysis algorithm to find smallest font
- **Tab 6**: `PreviewMouseWheel` event with modifier key detection

## 🎯 Use Cases

- **Text Editors** - Add zoom functionality to document editors
- **Accessibility** - Ensure readable text for users with visual impairments
- **Content Creation Tools** - WYSIWYG editors with zoom controls
- **Learning Resource** - Study different WPF zoom implementation patterns

## 🤝 Contributing

Feel free to fork this project and submit pull requests for improvements or additional zoom implementation methods!

## 📄 License

This project is provided as-is for educational and development purposes.

## 🙏 Acknowledgments

Built with WPF (Windows Presentation Foundation) targeting .NET Framework 4.8

---

**Note**: Each implementation includes detailed documentation within the application explaining advantages, limitations, and proper usage.

