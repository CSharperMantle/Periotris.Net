# Contribute to Periotris.Net

Periotris.Net is an open-source project where anyone can take part.

The key words "MUST", "MUST NOT", "REQUIRED", "SHALL", "SHALL NOT", "SHOULD", "SHOULD NOT", "RECOMMENDED", "MAY", and "OPTIONAL" in this document are to be interpreted as described in [RFC 2119](https://www.ietf.org/rfc/rfc2119.txt).

## Reporting a bug, feature request, question, etc.

Bug reports and feature requests are hosted on [GitHub Issues](https://github.com/CSharperMantle/Periotris.Net/issues). You SHOULD use the Markdown template below for bug reports.

```markdown
## 1. Description
A clear and concise description of what the bug is.

## 2. Steps To Reproduce
Steps to reproduce the behavior. E.g.:
1. Go to '...'
2. Click on '....'
3. Scroll down to '....'
4. See error

## 3. Expected Behavior
A clear and concise description of what you expected to happen.

**Note: Screenshots**
If applicable, add screenshots to help explain your problem.

## 4. Environment
 - OS: [e.g. Windows]
 - Periotris.Net Version: [e.g. 1.8.0]
 - Installed Via: [e.g. GitHub Release]

## 5. Additional context (optional)
Add any other context about the problem here.
```

## Submitting a patch, feature implementation, etc.

Patches MUST be submitted as [pull requests](https://github.com/CSharperMantle/Periotris.Net/pulls).

Your pull request MUST meet the following rules before it can be accepted:

* A pull request MUST contain a body.
* A pull request MUST be linked one or more issues. If there are no issues stating the problem the pull request is to fix, please open a issue before submitting a pull request.
* Commits in a pull request MUST comply with [Convenctional Commits v1.0.0](https://www.conventionalcommits.org/en/v1.0.0/) rules, with the following constraints:
    * The `type` field MUST contain one of the following nouns: `build`, `chore`, `ci`, `docs`, `feat`, `fix`, `impl`, `perf`, `refactor`, `style`, `test`, `other`.
        * Labels `feat` and `fix` are essentially the same as defined in [Convenctional Commits v1.0.0](https://www.conventionalcommits.org/en/v1.0.0/).
        * Label `build` is used when changes are for changes related to build systems, such as bumping version numbers, fixing a broken build, or build stage optimizations.
        * Label `chore` is used especially for trivial changes. Not to be confused with `refactor` and `style`.
        * Label `ci` is used for continuous integration system testing and troubleshooting.
        * Label `docs` is used for documentation-related changes.
        * Label `impl` is used for indicating stages of implementation a `feat`, `fix` or `perf`. `impl`s are usually used as checkpoints for a conclusive `feat`, `fix` or `perf` commit.
        * Label `perf` is used specifically for performance-related optimizations.
        * Label `refactor` is used, usually with a tool, when refactoring the project.
        * Label `style` is used with a automatic format tool.
        * Label `test` is used for unit testing.
        * Label `other` is a default option for any changes that can not fit into said tags.
* A pull request SHOULD be able to pass all related CI pipelines, also known as 'checks'.
