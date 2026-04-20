//HintName: test_constraint-dom-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

public class testCnstDomEnumInp
  : GqlpModelBase
  , ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp>? AsEnumCnstDomEnumInpcnstDomEnumInp { get; set; }
  public ItestCnstDomEnumInpObject? As_CnstDomEnumInp { get; set; }
}

public class testCnstDomEnumInpObject
  : GqlpModelBase
  , ItestCnstDomEnumInpObject
{

  public testCnstDomEnumInpObject
    ()
  {
  }
}

public class testRefCnstDomEnumInp<TType>
  : GqlpModelBase
  , ItestRefCnstDomEnumInp<TType>
{
  public ItestRefCnstDomEnumInpObject<TType>? As_RefCnstDomEnumInp { get; set; }
}

public class testRefCnstDomEnumInpObject<TType>
  : GqlpModelBase
  , ItestRefCnstDomEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstDomEnumInpObject
    ( TType pfield
    )
  {
    Field = pfield;
  }
}

public class testJustCnstDomEnumInp
  : GqlpDomainEnum
  , ItestJustCnstDomEnumInp
{
  public new testEnumCnstDomEnumInp? Value { get; set; }
}
