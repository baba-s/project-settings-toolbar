using UnityEditor;
using UnityEngine;

public sealed class ProjectSettingsToolbar : EditorWindow
{
	private sealed class ButtonData
	{
		public readonly string m_command;

		public ButtonData( string command )
		{
			m_command = command;
		}
	}

	private const string TITLE = "Toolbar";
	private const float WINDOW_HEIGHT = 28;

	private static readonly GUILayoutOption[] BUTTON_OPTIONS =
	{
		GUILayout.MinWidth( 28 ),
		GUILayout.MaxWidth( 48 ),
		GUILayout.Height( 24 ),
	};

	private static readonly ButtonData[] BUTTON_DATA_LIST =
	{
		new ButtonData( "Input"						),
		new ButtonData( "Tags and Layers"			),
		new ButtonData( "Audio"						),
		new ButtonData( "Time"						),
		new ButtonData( "Player"					),
		new ButtonData( "Physics"					),
		new ButtonData( "Physics 2D"				),
		new ButtonData( "Quality"					),
		new ButtonData( "Graphics"					),
		new ButtonData( "Network"					),
		new ButtonData( "Editor"					),
		new ButtonData( "Script Execution Order"	),
	};

	[MenuItem( "Window/Project Settings Toolbar" )]
	private static void Hoge()
	{
		var win = GetWindow<ProjectSettingsToolbar>( TITLE );

		var pos = win.position;
		pos.height = WINDOW_HEIGHT;
		win.position = pos;

		var minSize = win.minSize;
		minSize.y = WINDOW_HEIGHT;
		win.minSize = minSize;

		var maxSize = win.maxSize;
		maxSize.y = WINDOW_HEIGHT;
		win.maxSize = maxSize;
	}

	private void OnGUI()
	{
		EditorGUILayout.BeginHorizontal();

		foreach ( var n in BUTTON_DATA_LIST )
		{
			var command = n.m_command;
			var path = string.Format( "Assets/ProjectSettingsToolbar/Editor/Textures/{0}.png", command );
			var image = AssetDatabase.LoadAssetAtPath<Texture2D>( path );
			var content = new GUIContent( image, command );
			if ( GUILayout.Button( content, BUTTON_OPTIONS ) )
			{
				var menuItemPath = string.Format( "Edit/Project Settings/{0}", command );
				EditorApplication.ExecuteMenuItem( menuItemPath );
			}
		}

		EditorGUILayout.EndHorizontal();
	}
}