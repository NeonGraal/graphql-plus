//HintName: Gqlp_Output_Impl.gen.cs
// Generated from Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Output;

public class Output_TypeOutput
  : Output_TypeObject
  , I_TypeOutput
{
}

public class Output_OutputBase
  : Output_ObjBase
  , I_OutputBase
{
  public _DualBase As_DualBase { get; set; }
}

public class Output_OutputTypeParam
  : Output_ObjTypeParam
  , I_OutputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public class Output_OutputField
  : Output_Field
  , I_OutputField
{
  public _InputParam parameters { get; set; }
  public _OutputEnum As_OutputEnum { get; set; }
}

public class Output_OutputAlternate
  : Output_Alternate
  , I_OutputAlternate
{
}

public class Output_OutputTypeArg
  : Output_ObjTypeArg
  , I_OutputTypeArg
{
  public _Identifier label { get; set; }
}

public class Output_OutputEnum
  : Output_TypeRef
  , I_OutputEnum
{
  public _Identifier field { get; set; }
  public _Identifier label { get; set; }
}
