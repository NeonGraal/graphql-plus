//HintName: Model_Intro_Output.gen.cs
// Generated from Intro_Output.graphql+

/*
*/

namespace GqlTest.Model_Intro_Output;

public interface I_TypeOutput
  : I_TypeObject
{
}
public class Output_TypeOutput
  : Output_TypeObject
  , I_TypeOutput
{
}

public interface I_OutputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}
public class Output_OutputBase
  : Output_ObjBase
  , I_OutputBase
{
  public _DualBase As_DualBase { get; set; }
}

public interface I_OutputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
public class Output_OutputTypeParam
  : Output_ObjTypeParam
  , I_OutputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public interface I_OutputField
  : I_Field
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}
public class Output_OutputField
  : Output_Field
  , I_OutputField
{
  public _InputParam parameters { get; set; }
  public _OutputEnum As_OutputEnum { get; set; }
}

public interface I_OutputAlternate
  : I_Alternate
{
}
public class Output_OutputAlternate
  : Output_Alternate
  , I_OutputAlternate
{
}

public interface I_OutputTypeArg
  : I_ObjTypeArg
{
  _Identifier label { get; }
}
public class Output_OutputTypeArg
  : Output_ObjTypeArg
  , I_OutputTypeArg
{
  public _Identifier label { get; set; }
}

public interface I_OutputEnum
  : I_TypeRef
{
  _Identifier field { get; }
  _Identifier label { get; }
}
public class Output_OutputEnum
  : Output_TypeRef
  , I_OutputEnum
{
  public _Identifier field { get; set; }
  public _Identifier label { get; set; }
}
