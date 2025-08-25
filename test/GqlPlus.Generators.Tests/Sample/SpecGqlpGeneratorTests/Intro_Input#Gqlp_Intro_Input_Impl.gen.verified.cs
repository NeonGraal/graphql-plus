//HintName: Gqlp_Intro_Input_Impl.gen.cs
// Generated from Intro_Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Input;

public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public class Output_InputBase
  : Output_ObjBase
  , I_InputBase
{
  public _DualBase As_DualBase { get; set; }
}

public class Output_InputTypeParam
  : Output_ObjTypeParam
  , I_InputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public class Output_InputField
  : Output_Field
  , I_InputField
{
  public _Constant default { get; set; }
}

public class Output_InputAlternate
  : Output_Alternate
  , I_InputAlternate
{
}

public class Output_InputTypeArg
  : Output_ObjTypeArg
  , I_InputTypeArg
{
}

public class Output_InputParam
  : Output_InputBase
  , I_InputParam
{
  public _Modifiers modifiers { get; set; }
  public _Constant default { get; set; }
}
