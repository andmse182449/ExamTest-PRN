   M S B A M L   `   `   `  ����D  @ExamTest2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ExamTest_PRN212ExamTest_PRN212  5   	   &     ExamTest_PRN212.StudentQuestions   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ExamTest_PRN212     5   	   -   5          � WindowStyle$
  None=�5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowState$ 	Maximized=�5
   	    � Topmost$
 True��5   	    � Title$ StudentQuestions��5   	    � WindowStartupLocation$ CenterScreen=�6"   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $��0,0,0,10q�6I   $��0��6[   .+�5      �� $��Quiz Application��6   $��24(�60   $
��Bold"�6>   $��Center=�6P   �� 5      -   5         ��Name$ StudentInfoTextBlock��5      $��16(�66   $��Center=�6D   5      �� 5   
   $��1��6   .+�5      � -   5        	 �Name$	 QuestionProgressBar��5      $��20��67   $��0,0,0,10q�6C   
 � Minimum$
 0Q�6U    � Maximum$	 100Q�6a   �� 5      -   5        $ QuestionText��5      $��20(�6.   $��0,0,0,20q�6<   �� 5!      -   5         ��Name$ OptionsPanel��5!      $	��200��6/   5#      5$      �� 5&   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��0,20,0,0q�6X   .+�5'      �� -   5         ��Name$ SubmitCheckBox��5'      $��I want to submit��6/   $��0,0,10,0q�6�   �� 5(      -   5         ��Name$ PreviousButton��5(      $��Previous��6-   $	��100��6@   $��30��6L   ${�False��6u   $��0,0,10,0q�6�   �� 5)      -   5        $ SubmitButton��5)      $��Submit��6+   $	��100��6<   $��30��6H   6T   �� 5*      -	   5        $ 
NextButton��5*      $
��Next��6)   $	��100��68   $��30��6D   $��10,0,0,0q�6i   5+      5,      5-      