const fs = require('fs');

const filePath = process.argv[2];
const index = process.argv[3];
const searchKey = process.argv[4];

fs.readFile(filePath, 'utf8', function(err, data){
    if(!err){
        const fileContents = data?.split('\n');
        if(+index >= fileContents.length){
            console.log('ERROR : Invalid Index')
        }
        else{
            const splittedContent = fileContents?.map(x => x?.replace('\r','')?.replace(';','')?.split(','));
            const findedIndex = splittedContent?.findIndex(x => x[+index]?.toLowerCase() == searchKey?.toLowerCase());
            console.log(fileContents[findedIndex]);
        }
    }
    else{
        console.log('ERROR : ', err)
    }
});