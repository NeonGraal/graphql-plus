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

public interface IField
{
  String strings { get; }
}
public class DualField
{
  public String strings { get; set; }
}

public interface IParam
{
  Many afterId { get; }
  Many beforeId { get; }
  String AsString { get; }
}
public class InputParam
{
  public Many afterId { get; set; }
  public Many beforeId { get; set; }
  public String AsString { get; set; }
}

public interface IAll
{
  Field items { get; }
  String AsString { get; }
}
public class OutputAll
{
  public Field items { get; set; }
  public String AsString { get; set; }
}
