   M S B A M L   `   `   `  ����D  @ExamTest2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ExamTestExamTest  5   	        ExamTest.AddQuestionWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ExamTest     5   	     � Title$  AddQuestionWindow��5   	   $	��450��6#   $	��800��60    � WindowStartupLocation$ CenterScreen=�6<   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Question Text:��6   $��0��6*   $��0��67   $��	0,0,10,10q�6G   �� 5   
   -   5         ��Name$ QuestionTextBox��5      $��0��6+   $��1��68   $��0,0,0,10q�6H    �� TextWrapping$
 Wrap=�6Z    �� AcceptsReturn$
 True��6n   $��60��6�   �� 5   
   $��	Option A:��6   $��1��6%   $��0��62   $��	0,0,10,10q�6B   �� 5   
   -   5        $ OptionATextBox��5      $��1��6*   $��1��67   $��0,0,0,10q�6G   �� 5    
   $��	Option B:��6   $��2��6%   $��0��62   $��	0,0,10,10q�6B   �� 5!   
   -   5        $ OptionBTextBox��5!      $��2��6*   $��1��67   $��0,0,0,10q�6G   �� 5#   
   $��	Option C:��6   $��3��6%   $��0��62   $��	0,0,10,10q�6B   �� 5$   
   -   5        $ OptionCTextBox��5$      $��3��6*   $��1��67   $��0,0,0,10q�6G   �� 5&   
   $��	Option D:��6   $��4��6%   $��0��62   $��	0,0,10,10q�6B   �� 5'   
   -   5        $ OptionDTextBox��5'      $��4��6*   $��1��67   $��0,0,0,10q�6G   �� 5)   
   $��Correct Answer:��6   $��5��6+   $��0��68   $��	0,0,10,10q�6H   �� 5*   
   -   5         ��Name$ CorrectAnswerComboBox��5*      $��5��62   $��1��6?   $��0,0,0,10q�6O   .@�5+      �� $��A��6   �� 5,      $��B��6   �� 5-      $��C��6   �� 5.      $��D��6   5/      �� 51   
   -   5        $��Add Question��51      $��6��6(   $��1��65   $��Right=�6E   $	��100��6a   $��30��6m   $��0,20,0,0q�6�   $��3��6�   $	��Top=�6�   �� 52   
   -   5        $��Import from Excel��52      $��6��6-   $��0��6:   $
��Left=�6J   $	��150��6e   $��30��6q   $��	0,20,10,0q�6}   $��3��6�   $	��Top=�6�   6�   �� 55   
    �� Orientation$ 
Horizontal=�6   $��8��6.   $��0��6;   $��2��6K   $��0,20,0,0q�6_   56      58      59      