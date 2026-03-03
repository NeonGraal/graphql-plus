//HintName: test_constraint-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class testCnstEnumOutp
  : GqlpModelImplementationBase
  , ItestCnstEnumOutp
{
  public ItestRefCnstEnumOutp<testEnumCnstEnumOutp>? AsEnumCnstEnumOutpcnstEnumOutp { get; set; }
  public ItestCnstEnumOutpObject? As_CnstEnumOutp { get; set; }
}

public class testCnstEnumOutpObject
  : GqlpModelImplementationBase
  , ItestCnstEnumOutpObject
{

  public testCnstEnumOutpObject
    ()
  {
  }
}

public class testRefCnstEnumOutp<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumOutp<TType>
{
  public ItestRefCnstEnumOutpObject<TType>? As_RefCnstEnumOutp { get; set; }
}

public class testRefCnstEnumOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefCnstEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefCnstEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
