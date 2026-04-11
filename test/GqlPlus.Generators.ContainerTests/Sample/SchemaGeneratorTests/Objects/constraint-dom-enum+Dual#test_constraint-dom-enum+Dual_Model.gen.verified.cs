//HintName: test_constraint-dom-enum+Dual_Model.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public class testCnstDomEnumDual
  : GqlpModelBase
  , ItestCnstDomEnumDual
{
  public ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual>? AsEnumCnstDomEnumDualcnstDomEnumDual { get; set; }
  public ItestCnstDomEnumDualObject? As_CnstDomEnumDual { get; set; }
}

public class testCnstDomEnumDualObject
  : GqlpModelBase
  , ItestCnstDomEnumDualObject
{

  public testCnstDomEnumDualObject
    ()
  {
  }
}

public class testRefCnstDomEnumDual<TType>
  : GqlpModelBase
  , ItestRefCnstDomEnumDual<TType>
{
  public ItestRefCnstDomEnumDualObject<TType>? As_RefCnstDomEnumDual { get; set; }
}

public class testRefCnstDomEnumDualObject<TType>
  : GqlpModelBase
  , ItestRefCnstDomEnumDualObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumDualObject
    ( TType field
    )
  {
    Field = field;
  }
}

public class testJustCnstDomEnumDual
  : GqlpDomainEnum
  , ItestJustCnstDomEnumDual
{
}
