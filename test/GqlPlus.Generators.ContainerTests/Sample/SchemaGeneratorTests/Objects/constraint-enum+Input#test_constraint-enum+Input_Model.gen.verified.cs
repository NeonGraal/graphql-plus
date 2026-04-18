//HintName: test_constraint-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public class testCnstEnumInp
  : GqlpModelBase
  , ItestCnstEnumInp
{
  public ItestRefCnstEnumInp<testEnumCnstEnumInp>? AsEnumCnstEnumInpcnstEnumInp { get; set; }
  public ItestCnstEnumInpObject? As_CnstEnumInp { get; set; }
}

public class testCnstEnumInpObject
  : GqlpModelBase
  , ItestCnstEnumInpObject
{

  public testCnstEnumInpObject
    ()
  {
  }
}

public class testRefCnstEnumInp<TType>
  : GqlpModelBase
  , ItestRefCnstEnumInp<TType>
{
  public ItestRefCnstEnumInpObject<TType>? As_RefCnstEnumInp { get; set; }
}

public class testRefCnstEnumInpObject<TType>
  : GqlpModelBase
  , ItestRefCnstEnumInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumInpObject
    ( TType field
    )
  {
    Field = field;
  }
}
