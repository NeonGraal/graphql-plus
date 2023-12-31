﻿using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse;

public interface IParser<TResult>
{
  IResult<TResult> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer;
}

public interface IParserArray<TResult>
{
  IResultArray<TResult> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer;
}

public class Parser<T>
{
  public interface I
  {
    IResult<T> Parse<TContext>(TContext tokens, string label)
      where TContext : Tokenizer;
  }

  public interface IA
  {
    IResultArray<T> Parse<TContext>(TContext tokens, string label)
      where TContext : Tokenizer;
  }

  public delegate I D();
  public delegate IA DA();

  public class L(D factory) : Lazy<I>(() => factory())
  {
    public static implicit operator L(D factory) => new(factory.ThrowIfNull());

    public IResult<T> Parse<TContext>(TContext tokens, string label)
      where TContext : Tokenizer
      => Value.Parse(tokens, label);
  }

  public class LA(DA factory) : Lazy<IA>(() => factory())
  {
    public static implicit operator LA(DA factory) => new(factory.ThrowIfNull());

    public IResultArray<T> Parse<TContext>(TContext tokens, string label)
      where TContext : Tokenizer
      => Value.Parse(tokens, label);
  }
}

public class Parser<I, T>
  where I : Parser<T>.I
{
  public delegate I D();

  public class L(D factory) : Lazy<I>(() => factory())
  {
    public static implicit operator L(D factory) => new(factory.ThrowIfNull());

    public I I => Value;
  }
}

public class ParserArray<I, T>
  where I : Parser<T>.IA
{
  public delegate I DA();

  public class LA(DA factory) : Lazy<I>(() => factory())
  {
    public static implicit operator LA(DA factory) => new(factory.ThrowIfNull());

    public I I => Value;
  }
}
