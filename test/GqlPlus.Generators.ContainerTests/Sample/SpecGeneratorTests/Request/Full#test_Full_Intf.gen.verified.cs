//HintName: test_Full_Intf.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

public interface Itest_Request
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  Itest_RequestObject? As__Request { get; }
}

public interface Itest_RequestObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier? Category { get; }
  Itest_Identifier? Operation { get; }
  Itest_Operation Definition { get; }
  Itest_Any? Parameters { get; }
}

public interface Itest_Identifier
  : IGqlpDomainString
{
}
