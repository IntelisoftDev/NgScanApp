   M S B A M L   `   `   `  ����D  @NgScanApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NgScanApp	NgScanApp  5   	       NgScanApp.DevSettings   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:NgScanApp     5   	     � Title$  Settings��5   	   $	��500��6   $��465.076��6'   .��5
      � $��0,0,2,2q�6   #��� ��6   .+�5   
   �� $��Right=�6   $��31��61   $��0,0,0,10q�6=   $��Bottom=�6O   $	��164��6j    �� Orientation$ 
Horizontal=�6v   .+�5      �� -   5         ��Name$ okBtn��5      $��Ok��6$   $
��Left=�61   $��Bottom=�6L   $��46��6g   $��19��6r   $	��5,0q�6~   #��� ��6�   6�   �� 5      -   5        $ applyBtn��5      $��Apply��6'   $
��Left=�67   $��Bottom=�6R   $��46��6m   $��19��6x   $��0,0,5,0q�6�   #��� ��6�   6�   �� 5      -   5        $ 	cancelBtn��5      $��Cancel��6(   $��46��69   $��0,12,0,0q�6D   #��� ��6o   5      �� 5   
   -   5         ��Name$ 
tabControl��5      $
��Left=�6)   $	��411��6D   $��7,15,0,0q�6Q   $	��Top=�6c   $	��445��6{   .@�5      �� $��General��6   .��5      � #��� ��6   $��-6,0,4,0q�6^   .+�5      � $	��124��6   $	��100��6'   $��
3,30,0,253q�64   $
��Left=�6H   .+�5      �� $��
Color Mode��6    $��Center=�65   $��
14,0,14,74q�6R   �� 5      -   5         ��Name$ 
colModeCmb��5   #   $	��120��67   $��20��6C   $��	2,30,0,50q�6O   $
��Left=�6b   .@�5      �� $��Black and White��6+   $
��Left=�6E   $	��118��6`   �� 5      $��Color��6+   $
��Left=�6;   $	��118��6V   �� 5      $��
Gray Scale��6+   $
��Left=�6@   $	��118��6[   5      5      5      5      �� 5      $��
Brightness��6   .��5      � ���	#FFE5E5E5$��-1,0,1,0q�6.   .+�5      � $	��149��6   $��110,10,17,0q�6(   $	��Top=�6=   $	��313��6U   .+�5       �� -   5         ��Name$ label0��5        $��
Brightness��60   $��0,0,0,20q�6E   �� 5!      -   5         ��Name$ brightSl��5!   g    � Maximum$	 255Q�6"    �� TickPlacement$ BottomRight=�60   	 �� TickFrequency$	 5Q�6L   
 �� Ticks$
  R�6^   $��10,26,154,104q�6y    � Value$	 100Q�6�   5"      �� 5#      -   5         ��Name$ textBox��5#   "   $��20��63    �� TextWrapping$
 Wrap=�6?   $��194,25,74,104q�6�    J� RenderTransformOrigin$ 1.212,-0.568&�6�   ��6S   ��  �� ElementName$ brightSl�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5$      -	   5        $ label1��5$       $��Contrast��60   $��
0,53,237,0q�6C   $��24��6W   $	��Top=�6c   �� 5%      -
   5        $ 
contrastSl��5%   !   $��10,87,154,42q�66   $	 255Q�6L   $	 100Q�6Z   $ BottomRight=�6f   $	 5Q�6�   �� 5&      -   5        $ textBox1��5&   "   $
��Left=�64   $��20��6O   $��
194,87,0,0q�6[   $
 Wrap=�6o   $	��Top=�6�   $��45��6�   $ 0.722,-0.329&�6�   ��6�   �� $ 
contrastSl��$ Value�$ PropertyChanged=�6�   5'      5(      5)      5*      5,      5-      