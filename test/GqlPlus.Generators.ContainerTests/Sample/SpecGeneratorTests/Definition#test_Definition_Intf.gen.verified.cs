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
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
  String AsString { get; }
  Unit AsUnit { get; }
}

public interface Itest_Internal
  : IGqlpInterfaceBase
{
  Null AsNull { get; }
  Void AsVoid { get; }
}

public interface Itest_Key
  : IGqlpInterfaceBase
{
  _Basic As_Basic { get; }
  _Internal As_Internal { get; }
  _Simple As_Simple { get; }
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
}

public interface Itest_Simple
  : IGqlpInterfaceBase
{
  _Enum As_Enum { get; }
  _Domain As_Domain { get; }
  _Union As_Union { get; }
}
