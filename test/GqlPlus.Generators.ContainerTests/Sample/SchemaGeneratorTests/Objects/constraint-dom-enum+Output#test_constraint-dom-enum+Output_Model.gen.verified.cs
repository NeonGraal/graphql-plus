//HintName: test_constraint-dom-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

public class testCnstDomEnumOutp
  : GqlpModelImplementationBase
  , ItestCnstDomEnumOutp
{
  public ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp>? AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; set; }
  public ItestCnstDomEnumOutpObject? As_CnstDomEnumOutp { get; set; }
}

public class testCnstDomEnumOutpObject
  : GqlpModelImplementationBase
  , ItestCnstDomEnumOutpObject
{

  public testCnstDomEnumOutpObject
    ()
  {
  }
}

public class testRefCnstDomEnumOutp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstDomEnumOutp<TType>
{
  public ItestRefCnstDomEnumOutpObject<TType>? As_RefCnstDomEnumOutp { get; set; }
}

public class testRefCnstDomEnumOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstDomEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public class testJustCnstDomEnumOutp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumOutp
{
  public new testEnumCnstDomEnumOutp? Value { get; set; }
}
