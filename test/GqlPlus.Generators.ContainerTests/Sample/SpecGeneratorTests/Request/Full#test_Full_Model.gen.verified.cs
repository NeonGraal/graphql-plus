//HintName: test_Full_Model.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

public class test_Request
  : GqlpModelBase
  , Itest_Request
{
  public string? AsString { get; set; }
  public Itest_RequestObject? As__Request { get; set; }
}

public class test_RequestObject
  : GqlpModelBase
  , Itest_RequestObject
{
  public Itest_Identifier? Category { get; set; }
  public Itest_Identifier? Operation { get; set; }
  public Itest_Operation Definition { get; set; }
  public Itest_Any? Parameters { get; set; }

  public test_RequestObject
    ( Itest_Operation definition
    )
  {
    Definition = definition;
  }
}

public class test_Identifier
  : GqlpDomainString
  , Itest_Identifier
{
}
