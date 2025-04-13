//HintName: Model_Intro_Input.gen.cs
// Generated from Intro_Input.graphql+

/*
*/

namespace GqlTest.Model_Intro_Input;

public interface I_TypeInput
{
}
public class Output_TypeInput
{
}

public interface I_InputBase
{
  _Identifier input { get; }
  _DualBase As_DualBase { get; }
}
public class Output_InputBase
{
  public _Identifier input { get; set; }
  public _DualBase As_DualBase { get; set; }
}

public interface I_InputField
{
  _Constant default { get; }
}
public class Output_InputField
{
  public _Constant default { get; set; }
}

public interface I_InputAlternate
{
  _Identifier input { get; }
}
public class Output_InputAlternate
{
  public _Identifier input { get; set; }
}

public interface I_InputTypeArg
{
  _Identifier input { get; }
}
public class Output_InputTypeArg
{
  public _Identifier input { get; set; }
}

public interface I_InputParam
{
  _Modifiers modifiers { get; }
  _Constant default { get; }
}
public class Output_InputParam
{
  public _Modifiers modifiers { get; set; }
  public _Constant default { get; set; }
}
