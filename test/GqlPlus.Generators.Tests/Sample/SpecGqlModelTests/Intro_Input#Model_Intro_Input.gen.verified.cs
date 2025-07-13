﻿//HintName: Model_Intro_Input.gen.cs
// Generated from Intro_Input.graphql+

/*
*/

namespace GqlTest.Model_Intro_Input;

public interface I_TypeInput
  : I_TypeObject
{
}
public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public interface I_InputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}
public class Output_InputBase
  : Output_ObjBase
  , I_InputBase
{
  public _DualBase As_DualBase { get; set; }
}

public interface I_InputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
public class Output_InputTypeParam
  : Output_ObjTypeParam
  , I_InputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public interface I_InputField
  : I_Field
{
  _Constant default { get; }
}
public class Output_InputField
  : Output_Field
  , I_InputField
{
  public _Constant default { get; set; }
}

public interface I_InputAlternate
  : I_Alternate
{
}
public class Output_InputAlternate
  : Output_Alternate
  , I_InputAlternate
{
}

public interface I_InputTypeArg
  : I_ObjTypeArg
{
}
public class Output_InputTypeArg
  : Output_ObjTypeArg
  , I_InputTypeArg
{
}

public interface I_InputParam
  : I_InputBase
{
  _Modifiers modifiers { get; }
  _Constant default { get; }
}
public class Output_InputParam
  : Output_InputBase
  , I_InputParam
{
  public _Modifiers modifiers { get; set; }
  public _Constant default { get; set; }
}
