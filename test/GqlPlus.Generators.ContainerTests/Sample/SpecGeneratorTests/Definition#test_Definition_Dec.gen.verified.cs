//HintName: test_Definition_Dec.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
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
  // No Base because it's Class
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
  String AsString { get; }
  Unit AsUnit { get; }
}

public interface Itest_Internal
  // No Base because it's Class
{
  Null AsNull { get; }
  Void AsVoid { get; }
}

public interface Itest_Key
  // No Base because it's Class
{
  _Basic As_Basic { get; }
  _Internal As_Internal { get; }
  _Simple As_Simple { get; }
}

public interface Itest_Object
  // No Base because it's Class
{
  Itest_ObjectObject? As__Object { get; }
}

public interface Itest_ObjectObject
  // No Base because it's Class
{
}

public interface Itest_Domain
  // No Base because it's Class
{
}

public interface Itest_Dual
  // No Base because it's Class
{
  Itest_DualObject? As__Dual { get; }
}

public interface Itest_DualObject
  // No Base because it's Class
{
}

public interface Itest_Enum
  // No Base because it's Class
{
}

public interface Itest_Input
  // No Base because it's Class
{
  Itest_InputObject? As__Input { get; }
}

public interface Itest_InputObject
  // No Base because it's Class
{
}

public interface Itest_Output
  // No Base because it's Class
{
  Itest_OutputObject? As__Output { get; }
}

public interface Itest_OutputObject
  // No Base because it's Class
{
}

public interface Itest_Union
  // No Base because it's Class
{
}

public interface Itest_Simple
  // No Base because it's Class
{
  _Enum As_Enum { get; }
  _Domain As_Domain { get; }
  _Union As_Union { get; }
}
