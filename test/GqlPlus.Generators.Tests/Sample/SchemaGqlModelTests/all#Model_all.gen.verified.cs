//HintName: Model_all.gen.cs
// Generated from all.graphql+

/*
Category all
Directive all
Option Schema
*/

namespace GqlTest.Model_all;

public interface IGuid
{
}
public class DomainGuid
  : IGuid
{
}

public enum One
{
  Two,
  Three,
}

public interface IMany
{
  Guid AsGuid { get; }
  Number AsNumber { get; }
}
public class UnionMany
  : IMany
{
  public Guid AsGuid { get; set; }
  public Number AsNumber { get; set; }
}

public interface IDualField {}

public interface IInputParam {}

public interface IOutputAll {}
