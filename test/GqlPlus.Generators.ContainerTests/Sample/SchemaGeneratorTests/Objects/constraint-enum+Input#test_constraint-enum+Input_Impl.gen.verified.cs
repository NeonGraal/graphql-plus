//HintName: test_constraint-enum+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public class testCnstEnumInp
  : GqlpModelImplementationBase
  , ItestCnstEnumInp
{
  public ItestRefCnstEnumInp<testEnumCnstEnumInp>? AsEnumCnstEnumInpcnstEnumInp { get; set; }
  public ItestCnstEnumInpObject? As_CnstEnumInp { get; set; }
}

public class testCnstEnumInpObject
  : GqlpModelImplementationBase
  , ItestCnstEnumInpObject
{

  public testCnstEnumInpObject
    ()
  {
  }
}

public class testRefCnstEnumInp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumInp<TType>
{
  public ItestRefCnstEnumInpObject<TType>? As_RefCnstEnumInp { get; set; }
}

public class testRefCnstEnumInpObject<TType>
  : GqlpModelImplementationBase
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
