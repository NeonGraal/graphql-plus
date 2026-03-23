//HintName: test_constraint-dom-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public class testCnstDomEnumInp
  : GqlpModelImplementationBase
  , ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp>? AsEnumCnstDomEnumInpcnstDomEnumInp { get; set; }
  public ItestCnstDomEnumInpObject? As_CnstDomEnumInp { get; set; }
}

public class testCnstDomEnumInpObject
  : GqlpModelImplementationBase
  , ItestCnstDomEnumInpObject
{

  public testCnstDomEnumInpObject
    ()
  {
  }
}

public class testRefCnstDomEnumInp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstDomEnumInp<TType>
{
  public ItestRefCnstDomEnumInpObject<TType>? As_RefCnstDomEnumInp { get; set; }
}

public class testRefCnstDomEnumInpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstDomEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}

public class testJustCnstDomEnumInp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumInp
{
  public new testEnumCnstDomEnumInp? Value { get; set; }
}
