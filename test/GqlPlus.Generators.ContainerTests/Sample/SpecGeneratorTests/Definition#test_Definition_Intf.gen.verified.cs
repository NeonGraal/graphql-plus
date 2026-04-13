//HintName: test_Definition_Intf.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

public enum bool
{
  false,
  true,
}

public enum GqlpNull
{
  null,
}

public enum GqlpUnit
{
  _,
}

public enum void
{
}

public interface decimal
  : IGqlpDomainNumber
{
}

public interface string
  : IGqlpDomainString
{
}

public interface Itest_Basic
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface Itest_Internal
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface Itest_Key
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface Itest_Object
  : IGqlpInterfaceBase
{
  Itest_ObjectObject? As__Object { get; }
}

public interface Itest_ObjectObject
  : IGqlpInterfaceBase
{
}

public interface Itest_Domain
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface Itest_Dual
  : IGqlpInterfaceBase
{
  Itest_DualObject? As__Dual { get; }
}

public interface Itest_DualObject
  : IGqlpInterfaceBase
{
}

public interface Itest_Enum
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface Itest_Input
  : IGqlpInterfaceBase
{
  Itest_InputObject? As__Input { get; }
}

public interface Itest_InputObject
  : IGqlpInterfaceBase
{
}

public interface Itest_Output
  : IGqlpInterfaceBase
{
  Itest_OutputObject? As__Output { get; }
}

public interface Itest_OutputObject
  : IGqlpInterfaceBase
{
}

public interface Itest_Union
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface Itest_Simple
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}
