   M S B A M L   `   `   `  ����D  @NgScanApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NgScanApp	NgScanApp  5          NgScanApp.mSlider   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:NgScanApp     5        � 	Resources  5	       )  %HorizontalSliderTrackNormalBackground �� Color % !HorizontalSliderTrackNormalBorder �� EndPoint �� 
StartPoint � Color � Offset  SliderRepeatButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType  CustomThumbForSlider  MyCustomStyleForSlider
 � RowDefinitions m�Name m� Fill m� 	Placement ��Name �� CornerRadius ��Name ]�Name ]� DecreaseRepeatButton �� DecreaseLarge ]� IncreaseRepeatButton �� IncreaseLarge ]� Thumb n�Name��%  &	        &	 #     &	 �     &	 �    &	 �    7   7  7  7  7  �� 5
   
   $ 	#FFE7EAEA��6H   �� 5   
   $	 0,1&�6H   $	 0,0&�6W   .��5      � $ 	#FFAEB1AF��6   $	 0.1Q�6-   � 5      $ White��6   $ .9Q�6)   5      �� 5   
   " ��60   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� .  6*   �� 5       � |� .  6*   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� 
������ 6$   5      5      5      �� 5   
   " n�6-   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� 5      �� 5       "	 n�6&   .R�5!      �� $��15��6!   $��15��6-   5"      5$      5%      �� 5'   
   " ��6/   .�5(      ��  � �� 5)      �� 5*      "	 ��6&   .R�5+      �� #��z��6!   #��z��6K   #��z��6w   ._�5,      � 
 5-   "   �� 5.   &   $
��Auto �64   �� 5/   &   $
��Auto �64   #��z��6B   �� 50   &   $
��Auto �64   .+�52   "   m� $ TopTick��6*   $y�	Collapsed=�6;   # z��6R   $	 Top=�6v   $��4��6�   $��0��6�   m� 53   "   $ 
BottomTick��6*   $y�	Collapsed=�6>   # z��6U   $ Bottom=�6y   $��4��6�   $��0��6�   �� 54   "   $ TrackBackground��6)   8��  8�� $��1q�57   )   $ 1��6=   $	��5,0q�58   )   $��Center=�66   $	��4.0��6Q   $��1��6^   ._�59   &   �� $��-6,-1q�6-   .+�5:   *   �� $ PART_SelectionRange��6H   $y�Hidden=�64   $	��4.0��6e   #��� ��5;   4   #��� ��5<   4   $	��1.0��5=   4   5>   '   5?   #   ]� 5@   "   $ 
PART_Track��6(   $��1��6<    5A   &   �� 5B   *   8�� #��Z 6j    5D   &   �� 5E   *   8�� #��Z 6h    5G   &   n� 5H   *   $ Thumb��60   8�� 
���   �6m   5J   #   5K      5L      5M      5O      5P      5Q      .��5R      � .+�5S      �� #��[ 6   5T      5U      