   M S B A M L   `   `   `  ���� D  @NgScanApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:NgScanApp	NgScanApp      NgScanApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:NgScanApp     -     �Name$  	NgScanApp�� � Title$ 	NgScanApp�� � WindowState$ 	Maximized=�$
��1920��$
��1080�� � Icon$ 
AppIco.ico�� � 	Resources  �� Source�� $ Decorations.xaml?�%    .��� 
�������.+�� -    �Name$ GridR��$	��281��
�������$��0,2,3,0q�$��Right=�.+�� $	��200��$	��179��$��
45,26,36,0q�$	��Top=�.+��� -    ��Name$ ScanBtn��$��60��   NoChromeButton#���   $��63��$	��Top=�$
��Left=���Z� ��Z� .��� $��48��$��48��.+��� $��
CamIco.png��$��48��$��48��$��Bottom=�� $��Center=�$	��Top=�$��112,110,108,0q��� -    ��Name$ 	DeviceCmb��  
FancyCombo#���  $��Center=�$��10,115,70,0q�$	��Top=�$	��120���� -   $ DeviceIdCmb��$
��Left=�$��
53,173,0,0q�$	��Top=�$	��120��$y�	Collapsed=��� -   $ ReadyCropBtn��$��30��$��10,65,98,84q���Z� ��Z� .���� -   	 ��Name$	 CropCbx��$��	Crop Tool���� -   $ 
previewBtn��#���   $��Right=�$	��Top=�$��42��$��42��$��0,9,0,0q�.��� $��Center=�$��Center=�.+��� $��Preview.png��$��Center=�$��Center=��� -	   
 ��Name$
 savePathTxt��$
��Left=�$��38��$��
11,262,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��237�����	#FF6BB0E0$��2q� �� SelectionBrush �	#FF6BB0E0���� *
savePath+ �� UpdateSourceTrigger$ PropertyChanged=��� -
   $ 	browseBtn��#���   $
��Left=�$��
25,305,0,0q�$	��Top=�$��45��$��45��.���� .+��� $��save.png��$��40��$��25��$��Center=�$��Center=��� $
��Save���� $��
10,381,0,0q�$
��Left=�$	��Top=�$��Manual Crop�����	#FF060606���	#FF6BB0E0$��2q�.��� .+��� -   $
 widthTxt��$
��Left=�$��17��$��	67,19,0,0q�$
 Wrap=�$	��Top=�$��42������ *wInch+$ Default=��� -    ��Name$ widthLbn��$��Width��$
��Left=�$��	10,10,0,0q�$	��Top=�$��52��
���   �$��30���� -   $ 	heightLbn��$��Height��$��30��$��52��
���   �$��	10,50,0,0q�$	��Top=�$
��Left=��� -   $
 	heightTxt��$
��Left=�$��17��$��	67,54,0,0q�$
 Wrap=�$	��Top=�$��42������ *hInch+$ Default=��� $��30��$��52��$��Crop X��
���   �$��
127,10,0,0q�$
��Left=�$	��Top=��� -   $
 cropxTxt��$��17��$��42��$��
184,16,0,0q�$
��Left=�$	��Top=� J� RenderTransformOrigin$ 0.667,1.676&����� *cropX+$ Default=��� $��30��$��52��$��Crop Y��
���   �$��
127,46,0,0q�$
��Left=�$	��Top=��� -   $
 cropyTxt��$��17��$��42��$��
184,54,0,0q�$ 0.631,0.382&�$
��Left=�$	��Top=����� *cropY+$ Default=��� -   $ dpiLbn��$��25��$��42��$	��DPI��
���   �$��	90,81,0,0q�$
��Left=�$	��Top=��� -   $
 dpiTxt��$��17��$��42��$��
129,85,0,0q�$
��Left=�$	��Top=����� *dpi+$ Default=��� -   $ label��$��
Save Image��$
��Left=�$��100,232,0,0q�$	��Top=�
���   ��� -    ��Name$ groupBox��$��Rotation��$
��Left=�$��
11,550,0,0q�$	��Top=�$��89��$	��237��
���   ����	#FF6BB0E0$��2q�.��� .+��� -   $
 rotL��#���   $
��Left=�$��	10,25,0,0q�$	��Top=�$��35��.���� $��rotateL.png��$	��Top=��� -   $
 rotR��#���   $��Right=�$	��Top=�$��35��$��	0,25,10,0q�.���� $��rotateR.png��$	��Top=��� -   $ posLbn��$	��110��$��25�����	#FF040404$��Right=�$��Bottom=�
�������$��
0,0,146,46q�$y�Hidden=��� -   $ 
tifTypeCBX��#���  $
��Left=�$��125,305,0,0q�$	��Top=�$	��120�� �� SelectedIndex$ 2��$y�Hidden=�.@��� $��	CCITT T.4���� $��	CCITT T.6���� $	��LZW���� $
��None���� $	��RLE���� $	��ZIP���� -   $ applyBtn��$��Apply��  RoundBlueButton#���  $��Center=�$	��Top=�$��185,515,36,0q��� -   $ settingsBtn��#���   $
��Left=�$��170,666,0,0q�$	��Top=�$��75��.��� .+��� $��SettingsIco.png��$��30��$��30���� -   $ 
refreshBtn��#���   $
��Left=�$��194,144,0,0q�$	��Top=�$��20��.��� .+��� $��refresh-512px.png��$��Center=�� -   $ GridL��$
��1049��$��	0,0,289,0q�
�������.+��� -    ��Name$ CanvasL��
�������.+��� -    ��Name$ ScanView��$	��875���� -   $ PvCanvas��$	��500��$	��500��
�������.+��� -    $ PreView��$	��500��$	��500��$
��Left=�$	��Top=��� 
���   �$	��500��$	��500��$��1q��� -!    ��Name$ selRect�����	#7F385681$	��300��$	��300��$��Center=�$��Center=� �� Left$	 104��
 �� Top$	 104��$y�Hidden=��� -"   $ label1��$��Preview��$ 14��$ 10�����	#99505050$��21.333(�$
��Bold"��� ���	#FF969696$
��0.01q�$
��Left=�$	��527��$��1623,270,0,0q�$	��Top=�$��2�� �� CornerRadius$ 5������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ White�� � Offset$ 0Q�� $ White��$ 1Q�� $ 	#FF646464��$
 0.53Q�� $ 	#FFC8C8C8��$ 0.774Q�� $ 	#FFC8C8C8��$	 0.3Q�