//HintName: test_constraint-enum-parent+Input_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

public class testCnstEnumPrntInp
  : GqlpModelImplementationBase
  , ItestCnstEnumPrntInp
{
  public ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp>? AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; set; }
  public ItestCnstEnumPrntInpObject? As_CnstEnumPrntInp { get; set; }
}

public class testCnstEnumPrntInpObject
  : GqlpModelImplementationBase
  , ItestCnstEnumPrntInpObject
{

  public testCnstEnumPrntInpObject()
  {
  }
}

public class testRefCnstEnumPrntInp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumPrntInp<TType>
{
  public ItestRefCnstEnumPrntInpObject<TType>? As_RefCnstEnumPrntInp { get; set; }
}

public class testRefCnstEnumPrntInpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumPrntInpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumPrntInpObject(TType field)
  {
    Field = field;
  }
}
