import httpx

token = 'Z'
links = '''
'''

for repo_raw in links.splitlines():
    z = repo_raw.split()
    if len(z) != 4:
        continue
    _, name, _, repo = z
    link_main = f'https://github.com/{name}/{repo}'
    
    link = f'https://raw.githubusercontent.com/{name}/{repo}/main/README.md'
    resp = httpx.get(link)
    zz = resp.text
    if resp.text.find('По теме видео практических работ 1-5 повторить реализацию игры на Unity.') != -1:
        print(1)
        print(name, repo)
        print(link)
        print(link_main)

    link = f'https://api.github.com/repos/{name}/{repo}/branches'
    resp = httpx.get(link, auth=('zlom_hakir',token))
    zz = resp.json()
    if len(zz) != 1:
        print(2)
        print([_['name'] for _ in zz])
        print(name, repo)
        print(link)
        print(link_main)

    link = f'https://api.github.com/repos/{name}/{repo}/git/trees/main?recursive=1'
    resp = httpx.get(link, auth=('ZV',token))
    zz = resp.json()
    try:
        zzz = [_['path'] for _ in zz['tree'] if _['path'].endswith('.md') and _['path'].count('/') == 0]
        if len(zzz) != 1:
            print(3)
            print(name, repo)
            print(link)
            print(link_main)
    except Exception as e:
        print(type(e))
        print(e)
        print(zz)
        print(name, repo)
        print(link)
        print(link_main)
