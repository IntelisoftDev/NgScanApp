   M S B A M L   `   `   `  ���� D  @NgScanApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NgScanApp	NgScanApp  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   NoChromeButton  �� 
TargetType �� Property �� Value �� 
TargetType �Name J� SnapsToDevicePixels �� Triggers P� Property P� Value	 �� 
TargetName  RoundTab
 �� CornerRadius �� Path �� RelativeSource �� AncestorType �� AncestorLevel �� Triggers ]� 
Conditions �� Property �� Value  
FancyCombo  ComboBoxToggleButton �� 	ClickMode d� 	IsChecked �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name  ComboBoxTextBox �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency � ActualWidth �� MaxDropDownHeight  ��Name! K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation"    DirectionalNavigation# �� Padding$ �� TextAlignment% � ColumnDefinitions& F�Name  SliderThumbStyle  AppSliderStyle' � RowDefinitions( �Name) ]� Thumb  RoundBlueButton* �� RadiusX+ �� RadiusY�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     !localclr-namespace:NgScanApp  %(  &	        &	 c    &	 o    '�� R    &	 �    &	 �
    &	 �
    &	 8    7  &	 �    �� "  ��.���  � ��
 ���� ��  � ��$ 1q���  � ��# � ����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� $ Chrome��#��z�� . .+��� #��z��#��z����. # z #��z�� P�  � {� .  . ���  � �� �#ADADAD�� $	 Chrome�� �@J�Opacity$	 0.5Q��� "  ��.���  � ��
 �   ���  � �� �� .R��� 
����������	#FF6BB0E0$	��1.5q�$
 5,0,0,0��._��� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1�� ]�  ��  �@��
IsSelected .  ��  �@J�IsMouseOver . /���  � �� �� .R��� 
�������.���� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1����  � ��
 �������  � �� �� .R��� ���	#FF6BB0E0���	#FF6BB0E0$	��1.5q�$
 5,0,0,0��._��� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1��P�  �@��
IsSelected . . ���  � �� �� .R��� 
����������	#FF333333$	��1.5q�$
 5,0,0,0��._��� ���� $ Header� �� *FindAncestor+$ TabItemL�$ 1���� "  ��.���  � �� �	#FF6BB0E0��  � ��$ 2q���  � �� �	#FF6BB0E0��  � ��
 �������  � �� �� " ��.R�� .+�d� $��ToggleButton��#��z��#��z��#��z��#���  $��2��|�.  $ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite�� .  #��z #��z #��z��$��	10,3,30,3q�$��Center=�$��Center=��� $ PART_EditableTextBox��#���  $��Center=�$��Center=�$��3,3,23,3q�|�. $y�Hidden=�# z ��Z� � $��Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $��DropDown�� . #��z #��z .+��� $  DropDownBorder��
�������$��2q�
��������� $��4,6,4,6q� . .���� ! . $" 	Contained=��� "  ��.���  �@J�SnapsToDevicePixels . ��  � ��$ 11(���  � ��$
 Bold"���  � ��
 �   ���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R��� $��Border��$# 2q�$��2q�$��2q�$
 0��
������ 
������ ._��� $$ Center=���  P�  �@��IsHighlighted . . ��� $	 Border�� � �� �	#996BB0E0��  � ��
 ������� "  d�.���  � �� �� " d�.R�� % �� �� $��32 �.+��� $  Border��$��2��$
 0��#��z��#��z��$��2q��� $��0��$
 0��
������ 
������ $��10q�F� $& Arrow��$��1��#��z��#��z��$��Center=�$��Center=�"����        � z  � � $�     	 P�  � {� .  . ��� $	 Border�� � ��
 ������� $	 Border�� � ��
 �������  � ��
 ������� $	 Arrow�� � ��
 ������� " ��.R��� $  PART_ContentHost��|�. �� "  n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  ��  � ��$ 18����  � ��$ 18����  � �� �� " n�.R�A� $��Ellipse��
����ح�$��1�����	#FF6BB0E0 P�  �@J�IsMouseOver . . ��� $	 Ellipse�� � ��
 �����P�  � {� .  . ��� $	 Ellipse�� � ��
 ������� "  ��.���  �@�OverridesDefaultStyle . ��  � �� �� " ��.R�� ' �� $
��auto ��� $	( row��$
��auto ��� $
��auto �% �� $
��auto ��� $( column��$��* ��� $
��auto �.+��� $��PART_Border�����#848484$��6q�$# 2q�$��1��$��1��#��z��$��4�����#c1c1c1$��Stretch=�$��Center=�]� $��
PART_Track��$��Stretch=�$��Center=�$��1��$��1��#��z��$��18��) n� 8��  �� "  ��.���  � ��
 �������  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R�� .+��� ���	#FF6BB0E0���	#FF6BB0E0$��40��$��20��$* 5��$+ 5���� #��z��#��z��