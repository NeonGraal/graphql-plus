//HintName: test_default_Enc.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_default;

public class testQuery
  : GqlpEncoderBase
  , ItestQuery
{
  public ItestQueryObject? As_Query { get; set; }
}

public class testQueryObject
  : GqlpEncoderBase
  , ItestQueryObject
{

  public testQueryObject
    ()
  {
  }
}

public class testMutation
  : GqlpEncoderBase
  , ItestMutation
{
  public ItestMutationObject? As_Mutation { get; set; }
}

public class testMutationObject
  : GqlpEncoderBase
  , ItestMutationObject
{

  public testMutationObject
    ()
  {
  }
}

public class testSubscription
  : GqlpEncoderBase
  , ItestSubscription
{
  public ItestSubscriptionObject? As_Subscription { get; set; }
}

public class testSubscriptionObject
  : GqlpEncoderBase
  , ItestSubscriptionObject
{

  public testSubscriptionObject
    ()
  {
  }
}

public class test_Schema
  : GqlpEncoderBase
  , Itest_Schema
{
  public Itest_SchemaObject? As__Schema { get; set; }
}

public class test_SchemaObject
  : GqlpEncoderBase
  , Itest_SchemaObject
{

  public test_SchemaObject
    ()
  {
  }
}
