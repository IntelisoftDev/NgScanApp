   M S B A M L   `   `   `  ���� D  @NgScanApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NgScanApp	NgScanApp      NgScanApp.SettingsDlg   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:NgScanApp       � Title$  SettingsDlg��$	��300��$	��315�� � 	Resources    NoChromeButton �� 
TargetType �� Property �� Value �� 
TargetType �Name J� SnapsToDevicePixels �� Triggers	 P� Property
 P� Value �� 
TargetName  RoundTab �� CornerRadius �� Path �� RelativeSource �� AncestorType �� AncestorLevel �� Triggers ]� 
Conditions �� Property �� Value  
FancyCombo  ComboBoxToggleButton �� 	ClickMode d� 	IsChecked �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name  ComboBoxTextBox �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency  � ActualWidth! �� MaxDropDownHeight" ��Name# K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation$   DirectionalNavigation% �� Padding& �� TextAlignment' � ColumnDefinitions( F�Name  SliderThumbStyle  AppSliderStyle) � RowDefinitions* �Name+ ]� Thumb  RoundBlueButton, �� RadiusX- �� RadiusY��%(  &	        &	 c    &	 o    '�� R    &	 �    &	 �
    &	 �
    &	 8    7  &	 �    �� " ��.���  � ��
 ���� ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� $ Chrome��#��z�� . .+��� #��z��#��z����. # z #��z�� P� 	 � {�
 .  . ���  � �� �#ADADAD�� $ Chrome�� �@J�Opacity$	 0.5Q��� " ��.���  � ��
 �   ���  � �� �� .R��� 
����������	#FF6BB0E0$	��1.5q�$ 5,0,0,0��._��� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1�� ]�  ��  �@��
IsSelected .  ��  �@J�IsMouseOver . /���  � �� �� .R��� 
�������.���� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1����  � ��
 �������  � �� �� .R��� ���	#FF6BB0E0���	#FF6BB0E0$	��1.5q�$ 5,0,0,0��._��� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1��P� 	 �@��
IsSelected
 . . ���  � �� �� .R��� 
����������	#FF333333$	��1.5q�$ 5,0,0,0��._��� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1���� " ��.���  � �� �	#FF6BB0E0��  � ��$ 2q���  � �� �	#FF6BB0E0��  � ��
 �������  � �� �� " ��.R�� .+�d� $��ToggleButton��#��z��#��z��#��z��#���  $��2��|�.  $ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite�� .  #��z #��z #��z��$��	10,3,30,3q�$��Center=�$��Center=��� $ PART_EditableTextBox��#���  $��Center=�$��Center=�$��3,3,23,3q�|�. $y�Hidden=�# z ��Z� � $��Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $��DropDown�� . #��z  #��z! .+��� $" DropDownBorder��
�������$��2q�
��������� $��4,6,4,6q� . .���� # . $$ 	Contained=��� " ��.���  �@J�SnapsToDevicePixels . ��  � ��$ 11(���  � ��$
 Bold"���  � ��
 �   ���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $��Border��$% 2q�$��2q�$��2q�$ 0��
������ 
������ ._��� $& Center=���  P� 	 �@��IsHighlighted
 . . ��� $ Border�� � �� �	#996BB0E0��  � ��
 ������� " d�.���  � �� �� " d�.R�� ' �� �� $��32 �.+��� $" Border��$��2��$ 0��#��z��#��z��$��2q��� $��0��$ 0��
������ 
������ $��10q�F� $( Arrow��$��1��#��z��#��z��$��Center=�$��Center=�"����        � z  � � $�     	 P� 	 � {�
 .  . ��� $ Border�� � ��
 ������� $ Border�� � ��
 �������  � ��
 ������� $ Arrow�� � ��
 ������� " ��.R��� $" PART_ContentHost��|�. �� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  ��  � ��$ 18����  � ��$ 18����  � �� �� " n�.R�A� $��Ellipse��
����ح�$��1�����	#FF6BB0E0 P� 	 �@J�IsMouseOver
 . . ��� $ Ellipse�� � ��
 �����P� 	 � {�
 .  . ��� $ Ellipse�� � ��
 ������� " ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R�� ) �� $
��auto ��� $	* row��$
��auto ��� $
��auto �' �� $
��auto ��� $* column��$��* ��� $
��auto �.+��� $��PART_Border�����#848484$��6q�$% 2q�$��1��$��1��#��z��$��4�����#c1c1c1$��Stretch=�$��Center=�]� $��
PART_Track��$��Stretch=�$��Center=�$��1��$��1��#��z��$��18��+ n� 8��  �� " ��.���  � ��
 �������  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R�� .+��� ���	#FF6BB0E0���	#FF6BB0E0$��40��$��20��$, 5��$- 5���� #��z��#��z��.��� -   $ settingsGrid��.+��� -   . ��Name$. 
tabControl��$
��Left=�$	��228��$	��Top=�$	��302�����	#FF646464��Z� .@��� $��
Brightness��#���  $
��Left=�$��Bottom=���Z� ��Z� .��� ���	#FF646464$��	0,1,-2,-1q�.+�� $	��112��$��
10,10,49,0q�$	��Top=�' �� $	��59* ��� $
��129* �.+��� -   / ��Name$/ label0��$��
Brightness��$��10,3,0,0q�$
��Left=�$��65��$��26��$	��Top=�
��������� -   0 ��Name$0 brightSl��1 � Maximum$	1 255Q�#���  2 �� TickPlacement$2 BottomRight=�3 �� TickFrequency$3 5Q�4 �� Ticks$4  R�$��
9,28,66,61q����	#FF464646$��2��5 � Value5 �� *
brightness+�� -   $ textBox��$��20��$��45��6 �� TextWrapping$
6 Wrap=�$��101,28,10,64q�7 J� RenderTransformOrigin$7 1.212,-0.568&�$��1������ *Value+8 �� ElementName$8 brightSl��9 �� UpdateSourceTrigger$9 Default=��� -   $/ label1��$��Contrast��$��	16,50,0,0q�$��24��$	��Top=�$7 
2.169,0.41&�$��55��
��������� -   $0 
contrastSl��#���  $��10,74,64,10q�$	1 255Q�$2 BottomRight=�$3 5Q�$7 -0.745,0.332&����	#FF464646$��2��5 �� *
contrast+�� -   $ textBox1��$
��Left=�$��20��$��
105,74,0,0q�$
6 Wrap=�$	��Top=�$��45��$7 0.722,-0.329&�$��1������ *Value+$8 
contrastSl��$9 Default=��� $��Color��#���  $
��Left=�$��Bottom=�$��50����Z� ��Z� .��� ���	#FF646464$	��201��$	��Top=�$
��Left=�$	��302��$��	-1,0,-5,0q�.+��� $��
Color Mode��$
��Left=�$��37,0,0,0q�$	��Top=�
��������� -	   : ��Name$: 
colModeCmb��#���  $	��125��$��20��$��	10,31,0,0q�$
��Left=�$	��Top=�; �� SelectedIndex; �� *	colorMode+.@��� $��Black and White��$
��Left=�$	��118��
���   ��� $��Color��$
��Left=�$	��118��
�������
���   ��� $��
Gray Scale��$
��Left=�$	��118��
���   ��� -
   < ��Name$< groupBox��$��Bits Per Pixel��$
��Left=�$��	10,71,0,0q�$	��Top=�$	��120��$	��167��
���������Z� .��� .+�	� -   = 	�Name$= bpp1Rb��$
��1bpp��$
��Left=�$��	10,10,0,0q�$	��Top=�	� -   $= bpp8Rb��$
��8bpp��$
��Left=�$��
100,10,0,0q�$	��Top=�	� -   $= bpp24Rb��$��24bpp��$
��Left=�$��	10,50,0,0q�$	��Top=�	� -   $= bpp32Rb��$��32bpp��$
��Left=�$��
100,50,0,0q�$	��Top=�� $
��Left=�$��41��$��	0,228,0,0q�$	��Top=�$	��302�����	#FF646464.+��� -   > ��Name$> applyBtn��$��Apply��#���  $��40��$��20��$��252,11,10,10q�