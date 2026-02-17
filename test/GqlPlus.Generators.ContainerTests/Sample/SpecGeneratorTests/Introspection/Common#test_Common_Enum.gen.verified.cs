//HintName: test_Common_Enum.gen.cs
// Generated from {CurrentDirectory}Common.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Enum
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

public enum test_SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum test_TypeKind
{
  Basic = test_SimpleKind.Basic,
  Enum = test_SimpleKind.Enum,
  Internal = test_SimpleKind.Internal,
  Domain = test_SimpleKind.Domain,
  Union = test_SimpleKind.Union,
  Dual,
  Input,
  Output,
}
