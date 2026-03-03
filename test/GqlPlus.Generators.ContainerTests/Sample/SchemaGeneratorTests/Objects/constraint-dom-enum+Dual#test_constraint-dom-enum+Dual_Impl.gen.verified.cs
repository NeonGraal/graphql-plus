//HintName: test_constraint-dom-enum+Dual_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Dual;

public class testCnstDomEnumDual
  : GqlpModelImplementationBase
  , ItestCnstDomEnumDual
{
  public ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual>? AsEnumCnstDomEnumDualcnstDomEnumDual { get; set; }
  public ItestCnstDomEnumDualObject? As_CnstDomEnumDual { get; set; }
}

public class testCnstDomEnumDualObject
  : GqlpModelImplementationBase
  , ItestCnstDomEnumDualObject
{

  public testCnstDomEnumDualObject
    ()
  {
  }
}

public class testRefCnstDomEnumDual<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstDomEnumDual<TType>
{
  public ItestRefCnstDomEnumDualObject<TType>? As_RefCnstDomEnumDual { get; set; }
}

public class testRefCnstDomEnumDualObject<TType>
  : GqlpModelImplementationBase
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
