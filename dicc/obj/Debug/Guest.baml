   M S B A M L   `   `   `  ����?  ;dicc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:diccdicc  5   	       
dicc.Guest   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:dicc     5   	     � Title$  Dicc - Guest mode��5   	   $	��800��6#   $
��1000��60   .��5	      � -   5         �Name$ content��5	   "   ���	#FF000000.+�5
   
   r� -   5         r�Name$ myGif��5
       r� Source$ 	stars.gif?�6E    r� LoadedBehavior$
 Play=�6X    r� Stretch$
 Fill=�6n    r� UnloadedBehavior$ Manual=�6}   � 5   
   
���   �$	��400��6"   .+�5   
   �� -   5        $
��logo��5   p   $��Center=�6   $	��100��6-   $��0,10,0,0q�6:   $	��Top=�6L   $	��240��6d   6p   �� 5   
    �� Orientation$ 
Horizontal=�6   $��40��6.   $	��Top=�6:   $��0, 140, 0,0q�6R   $��Center=�6g   .+�5      �� -   5           RoundCorner#���   5      $��Close this mode��6?   $��Center=�6Y   $	��330��6t    J� RenderTransformOrigin$ -0.385,-0.476&�6�   $��Center=�6�   $��40��6�   ��5      �� 5      	 �� EndPoint$	 0.5,1&�6.   
 �� 
StartPoint$
 0.5,0&�6?   .��5      �  � Color$ 	#FF666666��6+   � 5      $ White��6+    � Offset$ 1Q�69   5      5      5      �� 5   
   $=��7You are in Guest mode. You can only check translations.��6   $��Center=�6R   $��	0,115,0,0q�6o   $	��Top=�6�   $	��305��6�   
�������6�   �� 5   
   $ Vertical=�6   $	��Top=�6,   $��0, 200, 0, 0q�6D   $��Center=�6Z   .+�5      �� -   5         ��Name$
 word��5   z   $��23��6    �� TextWrapping$
 Wrap=�6#   $	��330��6W   
�������6z   �� 5      $��Type your word��6   $��Center=�6-   $	��Top=�6J   $	��330��6b   $��25��6n   
�������$��Center=�6�   �� 5      -   5        #���   5      $��Search/Clear��6;   $	��Top=�6R   $	��330��6j   $	 1,1&�6v   $��Center=�6�   $��40��6�   #��� ��6�   5      �� 5    
   -   5         ��Name$ result��5    �   $��Center=�6   $	��350��61   $��	0,295,0,0q�6>   $
��Wrap=�6Q   $	��Top=�6e   $	��330��6}   $��14(�6�   
�������6�   5!      5"      5#      