//HintName: test_constraint-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class testCnstEnumOutp
  : GqlpModelBase
  , ItestCnstEnumOutp
{
  public ItestRefCnstEnumOutp<testEnumCnstEnumOutp>? AsEnumCnstEnumOutpcnstEnumOutp { get; set; }
  public ItestCnstEnumOutpObject? As_CnstEnumOutp { get; set; }
}

public class testCnstEnumOutpObject
  : GqlpModelBase
  , ItestCnstEnumOutpObject
{

  public testCnstEnumOutpObject
    ()
  {
  }
}

public class testRefCnstEnumOutp<TType>
  : GqlpModelBase
  , ItestRefCnstEnumOutp<TType>
{
  public ItestRefCnstEnumOutpObject<TType>? As_RefCnstEnumOutp { get; set; }
}

public class testRefCnstEnumOutpObject<TType>
  : GqlpModelBase
  , ItestRefCnstEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumOutpObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}
