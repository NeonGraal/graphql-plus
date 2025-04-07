//HintName: Model_Intro_Common.gen.cs
// Generated from Intro_Common.graphql+

/*
*/

namespace GqlTest.Model_Intro_Common;

public interface IOutput_Type {}

public interface IOutput_BaseType {}

public interface IOutput_ChildType {}

public interface IOutput_ParentType {}

public enum _SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum _TypeKind
{
  Basic = _SimpleKind.Basic,,
  Enum = _SimpleKind.Enum,,
  Internal = _SimpleKind.Internal,,
  Domain = _SimpleKind.Domain,,
  Union = _SimpleKind.Union,,
  Dual,
  Input,
  Output,
}

public interface IOutput_TypeRef {}

public interface IOutput_TypeSimple {}
