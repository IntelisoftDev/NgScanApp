   M S B A M L   `   `   `  ����D  @NgScanApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NgScanApp	NgScanApp  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   NoChromeButton  �� 
TargetType �� Property �� Value �� 
TargetType �Name J� SnapsToDevicePixels �� Triggers P� Property P� Value	 �� 
TargetName  RoundTab
 �� CornerRadius �� Path �� RelativeSource �� AncestorType �� AncestorLevel �� Triggers ]� 
Conditions �� Property �� Value  
FancyCombo  ComboBoxToggleButton �� 	ClickMode d� 	IsChecked �� Mode J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name  ComboBoxTextBox �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency � ActualWidth �� MaxDropDownHeight  ��Name! K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation"    DirectionalNavigation# �� Padding$ �� TextAlignment% � ColumnDefinitions& F�Name  SliderThumbStyle  AppSliderStyle' � RowDefinitions( �Name) ]� Thumb  RoundBlueButton* �� RadiusX+ �� RadiusY�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      !localclr-namespace:NgScanApp  5      %s  &	        &	 u    &	 a    '�� {    &	 6    &	 y    &	 �    &	 5    7  &	 �    �� 5      "  ��6#   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � ��$ 1q�6,   �� 5   
    � ��# � ��6'   �� 5   
    � ��$ Center=�67   �� 5	   
    � ��$ Center=�65   �� 5
   
    � ��$ 1q�6$   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � $ Chrome��6   #��z��6+    . .+�5      �� #��z��6+   #��z��6n   ��. # z 6�   #��z��6�   5       5      P� 5       � {� .  . �5      ��  � �� �#ADADAD6;   �� 5      $	 Chrome��68    �@J�Opacity$	 0.5Q�6L   5      5      5      5      �� 5      "  ��6   .�5   
   ��  � ��
 �   �6'   �� 5   
    � �� 5      �� 5      .R�5       �� 
����������	#FF6BB0E0$	��1.5q�6H   $
 5,0,0,0��6^   ._�5!      �� ��6+   �� $ Header� �� *FindAncestor+$ TabItemL�$ 1��5"      5#      5%       5&   
   ]� 5'       5(      �� 5)       �@��
IsSelected .  66   �� 5*       �@J�IsMouseOver . 67   /�5,      �� 5-       � �� 5.      �� 5/      .R�50   "   �� 
�������.��51   &   �� ��67   �� $ Header� �� *FindAncestor+$ TabItemL�$ 1��52   #   53      55      �� 56       � ��
 �����63   �� 57       � �� 58      �� 59      .R�5:   "   �� ���	#FF6BB0E0���	#FF6BB0E0$	��1.5q�6X   $
 5,0,0,0��6n   ._�5;   &   �� ��67   �� $ Header� �� *FindAncestor+$ TabItemL�$ 1��5<   #   5=      5?      5A      P� 5B       �@��
IsSelected . . �5C      ��  � �� 5D      �� 5E      .R�5F      �� 
����������	#FF333333$	��1.5q�6P   $
 5,0,0,0��6f   ._�5G   "   �� ��63   �� $ Header� �� *FindAncestor+$ TabItemL�$ 1��5H      5I      5K      5L      5N      �� 5O      "  ��6   .�5P   
   ��  � �� �	#FF6BB0E06'   �� 5Q   
    � ��$ 2q�6,   �� 5R   
    � �� �	#FF6BB0E06(   �� 5S   
    � ��
 �����6'   �� 5T   
    � �� 5U      �� 5V      " ��6"   .R�5W      � .+�5X      d� $��ToggleButton��5Y      #��z��5Z   !   #��z��5[   !   #��z��5\      #���  5]   !   $��2��5^   !   |�.  $ Press=�5a   !    5`   !   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5a   5   �� 5b      $��ContentSite��5c   !    .  #��z 5e   !   #��z 5f   !   #��z��5g   !   $��	10,3,30,3q�5h   !   $��Center=�5i   !   $��Center=�5j   !   �� 5k      $ PART_EditableTextBox��6"   #���  5m   !   $��Center=�5n   !   $��Center=�5o   !   $��3,3,23,3q�5p   !   |�. $y�Hidden=�5r   !   # z 5s   !   ��5l   !   Z� 5s   !   � 5t      $��Popup��5u   !   $��Bottom=�5v   !   #��z 5w   !    . |�.  $��Slide=�5z   !   .��5{      � $��DropDown��5|   #    . #��z 5~   #   #��z 5   #   .+�5�   "   �� $  DropDownBorder��5�   )   
�������$��2q�5�   )   
�������5�   )   �� 5�   "   $��4,6,4,6q�6/    . .��5�   &   �� ! . $" 	Contained=�6D   5�   #   5�      5�      5�      5�      5�      5�      �� 5�      "  ��6   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��$ 11(�6%   �� 5�   
    � ��$
 Bold"�6'   �� 5�   
    � ��
 �   �6'   �� 5�   
    �@�OverridesDefaultStyle . 62   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      �� $��Border��5�   #   $# 2q�5�   %   $��2q�5�   %   $��2q�5�   %   $
 0��5�   %   
������ 
������ ._�5�      �� $$ Center=�6$   �� 5�   *   5�      5�       5�      P� 5�       �@��IsHighlighted . . �5�      �� $	 Border��6%    � �� �	#996BB0E06O   �� 5�       � ��
 �����6;   5�      5�      5�      5�      �� 5�      "  d�6)   .�5�   
   ��  � �� 5�      �� 5�      " d�6"   .R�5�      � % 5�      �� 5�      �� 5�      $��32 �6/   .+�5�      �� $  Border��5�      $��2��5�      $
 0��5�      #��z��5�      #��z��5�      $��2q�5�      �� 5�      $��0��5�      $
 0��5�      
������ 
������ $��10q�5�      F� 5�      $& Arrow��5�      $��1��5�      #��z��5�      #��z��5�      $��Center=�5�      $��Center=�5�      "����        � z  � � $�     	5�      5�       5�      P� 5�       � {� .  . �5�      �� $	 Border��6%    � ��
 �����6O   �� 5�      $	 Border��6%    � ��
 �����6P   �� 5�       � ��
 �����6;   �� 5�      $	 Arrow��6%    � ��
 �����6H   5�      5�      5�      5�      �� 5�      " ��6.   .R�5�   
   �� $  PART_ContentHost��6   |�. 6+   5�      �� 5�      "  n�6%   .�5�   
   ��  �@J�SnapsToDevicePixels . 60   �� 5�   
    �@�OverridesDefaultStyle .  62   �� 5�   
    � ��$ 18��6#   �� 5�   
    � ��$ 18��6"   �� 5�   
    � �� 5�      �� 5�      " n�6"   .R�5�      A� $��Ellipse��5�      
����ح�$��1��5�      ���	#FF6BB0E05�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� $	 Ellipse��6%    � ��
 �����6J   5�      P� 5�       � {� .  . �5�      �� $	 Ellipse��6%    � ��
 �����6J   5�      5�      5�      5�      �� 5�      "  ��6   .�5�   
   ��  �@�OverridesDefaultStyle . 62   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � ' 5�      �� 5�      $
��auto �6,   �� 5�      $	( row��6:   $
��auto �6,   6:   �� 5�      $
��auto �6,   % 5      �� 5     $
��auto �6/   �� 5     $( column��69   $��* �6/   69   �� 5     $
��auto �6/   .+�5     �� $��PART_Border��6!   ���#848484$��6q�5  2   $# 2q�5     $��1��5     $��1��6(   #��z��5	     $��4��5
     ���#c1c1c1$��Stretch=�5     $��Center=�5     ]� 5     $��
PART_Track��6    $��Stretch=�5     $��Center=�5     $��1��5     $��1��6,   #��z��5     $��18��5     ) 5     n� 5  "   8��  6(   5     5     5     5     5     �� 5     "  ��6$   .�5  
   ��  � ��
 �����6'   �� 5  
    � ��$ Center=�60   �� 5   
    � ��$ Center=�65   �� 5!  
    � �� 5"     �� 5#     " ��6"   .R�5$     � .+�5%     �� ���	#FF6BB0E0���	#FF6BB0E0$��40��6H   $��20��6S   $* 5��6_   $+ 5��6k   �� 5&     #��z��6+   #��z��5'  +   5(     5)     5+     5,     5-     