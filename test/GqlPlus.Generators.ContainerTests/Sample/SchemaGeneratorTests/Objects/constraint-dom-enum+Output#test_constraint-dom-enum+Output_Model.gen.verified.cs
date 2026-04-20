//HintName: test_constraint-dom-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public class testCnstDomEnumOutp
  : GqlpModelBase
  , ItestCnstDomEnumOutp
{
  public ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp>? AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; set; }
  public ItestCnstDomEnumOutpObject? As_CnstDomEnumOutp { get; set; }
}

public class testCnstDomEnumOutpObject
  : GqlpModelBase
  , ItestCnstDomEnumOutpObject
{

  public testCnstDomEnumOutpObject
    ()
  {
  }
}

public class testRefCnstDomEnumOutp<TType>
  : GqlpModelBase
  , ItestRefCnstDomEnumOutp<TType>
{
  public ItestRefCnstDomEnumOutpObject<TType>? As_RefCnstDomEnumOutp { get; set; }
}

public class testRefCnstDomEnumOutpObject<TType>
  : GqlpModelBase
  , ItestRefCnstDomEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumOutpObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}

public class testJustCnstDomEnumOutp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumOutp
{
  public new testEnumCnstDomEnumOutp? Value { get; set; }
}
