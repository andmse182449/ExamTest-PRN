   M S B A M L   `   `   `  ����D  @ExamTest2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ExamTestExamTest  5   	       ExamTest.ViewDetalWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ExamTest     5   	     � Title$  ViewDetalWindow��5   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5      �� -   5         ��Name$ ExerciseNameTextBlock��5      $
��Quiz��67   $��24(�6C   $
��Bold"�6Q   $��Center=�6c   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��10q�6;   .+�5      �� -   5         ��Name$ 
txtkeyword��5      $
��Left=�6*   $��0,0,10,0q�6E    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��195��6�   $��14(�6�   $��29��6�   �� 5      -   5         ��Name$ 	btnSearch��5      $��Search��6(   $
��Left=�69   $	��Top=�6T   $��14(�6�   $��28��6�   $��63��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ QuestionsDataGrid��5       $��2��6   	   AutoGenerateColumns$	 False��6]   $��10,49,10,10q�6y   
   
IsReadOnly$

 True��6�   ��6;   �� *	Questions+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Question��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *QuestionText+6X     5      $ Option A��6%   $ * 6S    67   �� *	OptionA+6S     5      $ Option B��6%   $ * 6S    67   �� *	OptionB+6S     5      $ Option C��6%   $ * 6S    67   �� *	OptionC+6S     5      $ Option D��6%   $ * 6S    67   �� *	OptionD+6S     5       $ Correct Answer��6%   $ * 6_    6=   �� *CorrectAnswer+6_   5"      �� 5$   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5%      �� -   5        $ 	btnDelete��5%      $��Delete��6(   $
��Left=�69   $	��120��6T   $��30��6`   $��10q�6l   $	��Top=�6x   ${�false��6�   6�   �� 5&      -   5        $ AddQuestionButton��5&      $��Add Question��60   $	��120��6G   $��30��6S   $��10q�6_   6k   �� 5'      -   5        $ ListStudentMarksButton��5'      $��View List Student Marks��65   $	��150��6W   $��30��6c   $��10q�6o   6{   �� 5(      -   5        $ CloseButton��5(      $��Close��6*   $	��100��6:   $��30��6F   $��10q�6R   6^   5)      5+      5,      