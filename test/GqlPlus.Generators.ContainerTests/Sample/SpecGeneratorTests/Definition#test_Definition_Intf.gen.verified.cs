//HintName: test_Definition_Intf.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
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
  : IGqlpModelImplementationBase
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
  String AsString { get; }
  Unit AsUnit { get; }
}

public interface Itest_Internal
  : IGqlpModelImplementationBase
{
  Null AsNull { get; }
  Void AsVoid { get; }
}

public interface Itest_Key
  : IGqlpModelImplementationBase
{
  _Basic As_Basic { get; }
  _Internal As_Internal { get; }
  _Simple As_Simple { get; }
}

public interface Itest_Object
  : IGqlpModelImplementationBase
{
  Itest_ObjectObject? As__Object { get; }
}

public interface Itest_ObjectObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_Domain
  : IGqlpModelImplementationBase
{
}

public interface Itest_Dual
  : IGqlpModelImplementationBase
{
  Itest_DualObject? As__Dual { get; }
}

public interface Itest_DualObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_Enum
  : IGqlpModelImplementationBase
{
}

public interface Itest_Input
  : IGqlpModelImplementationBase
{
  Itest_InputObject? As__Input { get; }
}

public interface Itest_InputObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_Output
  : IGqlpModelImplementationBase
{
  Itest_OutputObject? As__Output { get; }
}

public interface Itest_OutputObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_Union
  : IGqlpModelImplementationBase
{
}

public interface Itest_Simple
  : IGqlpModelImplementationBase
{
  _Enum As_Enum { get; }
  _Domain As_Domain { get; }
  _Union As_Union { get; }
}
