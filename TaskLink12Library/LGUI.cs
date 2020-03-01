using System;

public partial class TLL
{
    /// <summary>
    /// Displays Input Dialog and returns User Input
    /// </summary>
    /// <param name="text">Main Text</param>
    /// <param name="title">Dialog Box Title</param>
    /// <param name="EnteredText">The Text that is already entered</param>
    /// <returns>entered text</returns>
    public static string BoxInput(string text, string title, string EnteredText = "")
    {
        try
        {
            string Input = StringCheck(Microsoft.VisualBasic.Interaction.InputBox(text,
                       title, EnteredText, 0, 0));

            Log($"Input Box: { title} : {text}");
            return Input;
        }
        catch (Exception ex)
        {
            Log(ex, "InputBox");
            return string.Empty;
        }
    }

    /// <summary>
    /// Shows Yes No Box and returns Answer
    /// </summary>
    /// <param name="text">Main Text in Box</param>
    /// <param name="title">Windows Title</param>
    /// <returns>Wether Yes was clicked</returns>
    public static bool BoxConfirm(string text, string title)
    {
        try
        {
            Log("Confirmation Box: " + title + " - " + text);
            if (Microsoft.VisualBasic.Interaction.MsgBox(
                text, Microsoft.VisualBasic.MsgBoxStyle.YesNo, title)
                == Microsoft.VisualBasic.MsgBoxResult.Yes)
            {
                Log("Result: Yes");
                return true;
            }
            else
            {
                Log("Result: No");
                return false;
            }
        }
        catch (Exception ex)
        {
            Log(ex, "Confirmation Box");
            return false;
        }
    }
}
