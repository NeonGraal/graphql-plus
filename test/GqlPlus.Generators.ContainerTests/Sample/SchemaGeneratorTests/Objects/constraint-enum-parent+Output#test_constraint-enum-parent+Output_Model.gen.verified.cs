//HintName: test_constraint-enum-parent+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public class testCnstEnumPrntOutp
  : GqlpModelBase
  , ItestCnstEnumPrntOutp
{
  public ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp>? AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; set; }
  public ItestCnstEnumPrntOutpObject? As_CnstEnumPrntOutp { get; set; }
}

public class testCnstEnumPrntOutpObject
  : GqlpModelBase
  , ItestCnstEnumPrntOutpObject
{

  public testCnstEnumPrntOutpObject
    ()
  {
  }
}

public class testRefCnstEnumPrntOutp<TType>
  : GqlpModelBase
  , ItestRefCnstEnumPrntOutp<TType>
{
  public ItestRefCnstEnumPrntOutpObject<TType>? As_RefCnstEnumPrntOutp { get; set; }
}

public class testRefCnstEnumPrntOutpObject<TType>
  : GqlpModelBase
  , ItestRefCnstEnumPrntOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumPrntOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
